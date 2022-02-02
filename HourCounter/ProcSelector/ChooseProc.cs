using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using ProcessLib;
namespace HourCounter
{
    public partial class ChooseProc : Form
    {
        HourCounter mainForm;
        IProcess selectedProc = null;

        public IProcess selResult
        {
            get { return selectedProc; }
        }

        public ChooseProc()
        {
            InitializeComponent();
        }

        Icon icoBuffer;
        void UpdateAllProcesses()
        {
            ProcessList.Items.Clear();
            foreach (Process proc in Process.GetProcesses())
            {
                if (IProcess.badProcs.Contains(proc.ProcessName))
                    continue;
                try
                {
                    icoBuffer = IProcess.ResizeIcon(Icon.ExtractAssociatedIcon(proc.MainModule.FileName), new Size(16, 16));
                    ProcessList.Items.Add(new IProcess(proc, icoBuffer));
                }
                catch (System.InvalidOperationException) { }
                catch (System.ComponentModel.Win32Exception) { }
            }
        }

        private void ChooseProc_Load(object sender, EventArgs e)
        {
            mainForm = (HourCounter)this.Owner;
            UpdateAllProcesses();
        }

        private void ProcessList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == 0)
                return;

            var rect = new Rectangle(e.Bounds.X, e.Bounds.Y + 1, 16, 16);
            e.DrawBackground();
            IProcess currentProc = ((IProcess)ProcessList.Items[e.Index]);
            e.Graphics.DrawIconUnstretched(currentProc.icon, rect);
            e.Graphics.DrawString((currentProc.proc.MainWindowTitle == "" ? currentProc.proc.ProcessName : currentProc.proc.MainWindowTitle) + " : " + currentProc.proc.Id,
            e.Font, Brushes.White, new Rectangle(e.Bounds.X + 18, e.Bounds.Y + 4, e.Bounds.Width + 100, e.Bounds.Height), StringFormat.GenericDefault);
            //e.DrawFocusRectangle();

        }

        private void ChooseProc_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.CanChoose = true;
        }

        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ProcessList.SelectedItem == null)
            {
                SelectProc.Enabled = false;

                pictureBox1.Image = null;
                procInfo.Text = "";
            }
            else
            {
                SelectProc.Enabled = true;

                IProcess selProc = (IProcess)ProcessList.SelectedItem;
                pictureBox1.Image = IProcess.ResizeIcon(selProc.icon, new Size(32, 32)).ToBitmap();
                procInfo.Text = 
                    "Process name: " + (selProc.proc.MainWindowTitle == "" ? selProc.proc.ProcessName : selProc.proc.MainWindowTitle) +
                                                                                                   "\nProcess ID: " + selProc.proc.Id +
                                                                                 "\nProcess Path: " + selProc.proc.MainModule.FileName;
                selectedProc = selProc;
            }
        }

        private void SelectProc_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedIndex == null)
                return;
            else
            {
                mainForm.AddSelectedProc(selectedProc);
                mainForm.CanChoose = true;
                this.Close();
            }
        }
    }
}
