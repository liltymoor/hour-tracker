using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLib;
using System.Diagnostics;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using HourBinary;
namespace ProcessLib
{
    public class IProcess
    {
        public Process proc;
        public Time timeIn;
        public Icon icon;
        public static List<string> badProcs = new List<string>();
        
        public IProcess(Process process, Icon ico)
        {
            proc = process;
            icon = ico;
        }
        public IProcess(Process process)
        {
            proc = process;
            icon = null;
        }

        //Turned Off proc
        public IProcess(Time time, string path)
        {
            proc = null;
            timeIn = time;
            icon = Icon.ExtractAssociatedIcon(path);
        }

        /*
        public static bool IsRunning(ProcBinary proc)
        {
            if (proc == null)
                return false;

            Process[] processes = Process.GetProcesses();

            foreach (Process item in processes)
            {
                try
                {
                    if (badProcs.Contains(item.ProcessName))
                        continue;

                    if (String.Equals(item.MainModule.FileName, proc.ProcPath, StringComparison.OrdinalIgnoreCase))
                        return true;
                    else
                        item.Dispose();
                }
                catch (System.ComponentModel.Win32Exception) { badProcs.Add(item.ProcessName); item.Dispose(); }
            }

            /*
            try
            {
                //Console.WriteLine("Ищем процесс " + proc.ProcName);
                foreach (Process item in Process.GetProcesses())
                {
                    //Console.WriteLine(item.ProcessName + " *|* " + proc.ProcName);
                    try
                    {
                        if (item.MainModule.FileName == proc.ProcPath)
                            return true;
                    }
                    catch {  }; // Console.WriteLine("Отказано в доступе.");
                }
            }
            catch (ArgumentException)
            {
                return false;
            }
            */ /*
            Console.WriteLine("No match - process is offline");
            return false;
        }
        */
        public static Icon ResizeIcon(Icon icon, Size size)
        {
            Bitmap bitmap = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(icon.ToBitmap(), new Rectangle(Point.Empty, size));
            }
            return Icon.FromHandle(bitmap.GetHicon());
        }
    }

}
