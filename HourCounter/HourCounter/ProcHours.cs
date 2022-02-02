using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using TimeLib;
using ProcessLib;
using HourBinary;
using Microsoft.Win32;

namespace HourCounter
{
    public partial class HourCounter : Form
    {
        Loading formLoad;
        bool isLoaded;
        public bool isLoad
        { get { return isLoaded; } }

        ChooseProc form;
        HourCounter formH;

        List<ProcBinary> trackingList;
        public ProcBinary selProc;

        public string binaryPath = System.IO.Directory.GetCurrentDirectory() + "\\data.dat";

        int counterToSave;
        int counterToRedrawList;
        int auto_sav_every = 10;

        float showExp = 0f;

        public HourCounter()
        {
            formH = this;
            InitializeComponent();
            notifyIcon.Icon = this.Icon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                 new MenuItem("Open", Open),new MenuItem("Exit", Exit)});
            counterToSave = 0;
            counterToRedrawList = 0;
        }

        private void HourCounter_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.CenterToScreen();
            formLoad = new Loading();
            formLoad.Owner = this;
            formLoad.Show();

            this.Invalidate();
            LoadBinary();
        }

        

        void LoadBinary()
        {
            trackingList = new List<ProcBinary>();
            trackList.Items.Clear();
            List<ProcBinary> binaries = ProcBinary.Result(binaryPath);
            Console.WriteLine("Кол-во трекеров: " + binaries.Count);
            foreach (ProcBinary note in binaries)
            {
                AddSelectedProc(note);
                note.ShowConsole();
            }
        }

        private void chooseProc_Click(object sender, EventArgs e)
        {
            form = new ChooseProc();
            form.Owner = this;
            form.Show();
            chooseProc.Enabled = false;
        }

        public bool CanChoose
        {
            get { return chooseProc.Enabled; }
            set { chooseProc.Enabled = value; }
        }

        public void AddSelectedProc(IProcess proc)
        {
            if (proc == null)
                return;

            ProcBinary newProc = new ProcBinary(
                (proc.proc.MainWindowTitle == "" ? proc.proc.ProcessName : proc.proc.MainWindowTitle),
                proc.proc.MainModule.FileName);

            newProc.Save_Result(binaryPath);

            trackingList.Add(newProc);
            trackList.Items.Add(newProc);
        }

        public void AddSelectedProc(ProcBinary proc)
        {
            if (proc == null)
                return;

            trackingList.Add(proc);
            trackList.Items.Add(proc);
        }

        private void HourCounter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                notifyIcon.Visible = true;
                this.Hide();
                e.Cancel = true;
            }
            else
                SaveTrackers();
        }

        void SaveTrackers()
        {
            foreach (ProcBinary trackProc in trackingList)
                trackProc.Correct_Result(binaryPath);
            Console.WriteLine("Трекеры сохранены");
        }

        void SaveTrackersT()
        {
            foreach (ProcBinary trackProc in trackingList)
                trackProc.Save_Result(binaryPath);
            Console.WriteLine("Файл перезаписан. Трекеры сохранены");
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
        }

        void Open(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            this.Show();
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            notifyIcon.Visible = false;

            Application.Exit();
        }

        private void trackList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
                return;

            var rect = new Rectangle(e.Bounds.X + 10, e.Bounds.Y + 2, 32, 32);
            e.DrawBackground();
            Console.WriteLine("List were redrawn");
            ProcBinary currentProc = ((ProcBinary)trackList.Items[e.Index]);
            e.Graphics.DrawIconUnstretched(IProcess.ResizeIcon(Icon.ExtractAssociatedIcon(currentProc.ProcPath), new Size(32, 32)), rect);
            e.Graphics.DrawString((currentProc.ProcName + "       " + currentProc.TimeIn.Hours + "h. " + currentProc.TimeIn.Minutes + "m."),
            e.Font, Brushes.White, new Rectangle(e.Bounds.X + 54, e.Bounds.Y + 11, e.Bounds.Width + 100, e.Bounds.Height), StringFormat.GenericDefault);
            //e.DrawFocusRectangle();
        }

        bool IsRunningProc(ProcBinary proc)
        {
            Process[] processes = Process.GetProcesses();

            foreach (Process item in processes)
            {
                    if (IProcess.badProcs.Contains(item.ProcessName))
                        continue;
                try
                {
                    if (String.Equals(item.MainModule.FileName, proc.ProcPath, StringComparison.OrdinalIgnoreCase))
                        return true;
                    else
                        item.Dispose();
                }
                catch (System.ComponentModel.Win32Exception) { IProcess.badProcs.Add(item.ProcessName); item.Dispose(); }
                catch (System.InvalidOperationException) { IProcess.badProcs.Add(item.ProcessName); item.Dispose(); }
                catch (System.NullReferenceException) { IProcess.badProcs.Add(item.ProcessName); item.Dispose(); }
            }
            return false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (trackingList == null)
                return;
            foreach (ProcBinary proc in trackingList)
            {
                bool value = false;
                Thread condition = new Thread(() =>
                {
                    value =
                    IsRunningProc(proc);
                });
                condition.Start();
                condition.Join();

                if (value)
                {
                    Time newTime = proc.TimeIn;
                    proc.NewData(newTime++, proc.ProcPath);
                }
            }

            if (isLoaded == false)
                isLoaded = true;

            if (selProc != null)
                procInfo.Text = "Process name: " + selProc.ProcName +
                                "\nTime spend: " + selProc.TimeIn.ToString() +
                                "\nFirst opened: " + selProc.TimeFrom.ToString();

            if (counterToRedrawList == 11)
            {
                counterToRedrawList = 0;
                trackList.Invalidate();
            }
            counterToRedrawList++;
            if (counterToSave == auto_sav_every)
            {
                SaveTrackers();
                counterToSave = 0;
                return;
            }
            counterToSave++;

        }

        private void trackList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (trackList.SelectedIndex == null)
                return;
            selProc = (ProcBinary)trackList.SelectedItem;
            if (selProc == null)
                return;
            procInfo.Text = "Process name: " + selProc.ProcName +
                "\nTime spend: " + selProc.TimeIn.ToString() +
                "\nFirst opened: " + selProc.TimeFrom.ToString();
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            if (selProc == null)
            {
                e.Graphics.Clear(this.BackColor);
                Console.WriteLine("Draw cleaared");
                return;
            }
            else
            {
                pictureBox1.Visible = true;
                e.Graphics.DrawIcon(IProcess.ResizeIcon(Icon.ExtractAssociatedIcon(selProc.ProcPath),
                    new Size(64, 64)), new Rectangle(0, 0, 64, 64));
            }
            Console.WriteLine("Draw completed");
        }

        private void deleteProc_Click(object sender, EventArgs e)
        {
            if (selProc == null)
                return;
            timer1.Enabled = false;
            ProcBinary.TruncateBinary(binaryPath);
            trackingList.Remove(selProc);
            trackList.Items.Remove(selProc);
            SaveTrackersT();
            LoadBinary();
            timer1.Enabled = true;
        }

        private void HourCounter_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, formH.Size.Height/2, formH.Width, formH.Height / 2));          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity = Math.Exp(showExp) * 0.01f;
            showExp+= 0.25f;
            if (this.Opacity >= 0.97f)
            {
                this.Opacity = 1f;
                timer2.Enabled = false;
            }
        }

        public void LoadComplete()
        {
            this.Show();
            timer2.Enabled = true;
        }

        private void gitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://github.com");    
        }
        internal string GetSystemDefaultBrowser()
        {
            string name = string.Empty;
            RegistryKey regKey = null;

            try
            {
                regKey = Registry.ClassesRoot.OpenSubKey("HTTP\\shell\\open\\command", false);
                name = regKey.GetValue(null).ToString().ToLower().Replace("" + (char)34, "");

                if (!name.EndsWith("exe"))
                    name = name.Substring(0, name.LastIndexOf(".exe") + 4);
            }
            catch (Exception ex) { }
            finally
            {
                if (regKey != null)
                    regKey.Close();
            }
            return name;
        }
    }
}
