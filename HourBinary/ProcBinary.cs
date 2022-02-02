using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using TimeLib;

namespace HourBinary
{
    [Serializable]
    public class ProcBinary : IComparable
    {
        long timeFrom;
        long timeSpend;
        byte[] processName;
        byte[] processPath;
        long pos;

        public ProcBinary(string procName, string procPath)
        {
            this.timeFrom = DateTime.Now.Ticks;
            this.timeSpend = Convert.ToInt64(0);
            this.processName = StringToByte(procName);
            this.processPath = StringToByte(procPath);
        }

        public ProcBinary()
        {
            this.timeFrom = DateTime.Now.Ticks;
            this.timeSpend = Convert.ToInt64(0);
            this.processName = StringToByte("");
            this.processPath = StringToByte("");
        }

        [NonSerialized]
        static Encoding encoding = System.Text.Encoding.GetEncoding(1251);

        private static byte[] StringToByte(string s)
        {
            char[] ar = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                ar[i] = s[i];
            }
            byte[] buff = encoding.GetBytes(ar);
            return buff;
        }

        private static string ByteArrayToString(byte[] b)
        {
            char[] buff = encoding.GetChars(b);
            string result = "";
            for (int i = 0; i < buff.Length; i++)
            {
                result += (char)buff[i];
            }
            return result;
        }

        public int CompareTo(object obj)
        {
            ProcBinary N = (ProcBinary)obj;
            if (this.timeSpend > N.timeSpend) return 1;
            if (this.timeSpend < N.timeSpend) return -1;
            return 0;
        }
        //Save to .dat file
        public void Save_Result(string filename)
        {
            FileStream fa = null;
            try
            {
                fa = new FileStream(filename, FileMode.Append);
                BinaryFormatter bw = new BinaryFormatter();
                Console.WriteLine("Append pos: " + fa.Position);
                pos = fa.Position;
                bw.Serialize(fa, this);
            }
            catch { }
            finally { fa.Close(); }
        }

        //Load from .dat file
        static public List<ProcBinary> Result(string filename)
        {
            List<ProcBinary> list = new List<ProcBinary>();
            FileStream stream = null;
            try
            {


                stream = new FileStream(filename, FileMode.OpenOrCreate);
                BinaryFormatter bf = new BinaryFormatter();
                Console.WriteLine("Длина записей: " + stream.Length);
                if (stream.Length > 0)
                {
                    int counter = 0;
                    long buffer = 0;
                    object Readed = null;
                    while ((Readed = bf.Deserialize(stream)) != null)
                    {
                        try { if ((int)Readed == 0) break; } catch { }
                        if ((ProcBinary)Readed == null)
                            break;
                        ProcBinary M = (ProcBinary)Readed;
                            list.Add(M); Console.WriteLine(stream.Position);
                        if (counter == 0)
                        {
                            M.pos = 0;
                            buffer = stream.Position;
                        }
                        else
                        {
                            M.pos = buffer;
                            buffer = stream.Position;
                        }
                        counter++;
                        M.ShowConsole();    
                    };
                }
            }
            catch { }
            finally { stream.Close(); }
            list.Sort();
            return list;

        }

        public bool Correct_Result(string filename)
        {
            long num = pos;
            bool result = false;
            if (num >= 0)
            {
                FileStream fw = null;
                try
                {
                    fw = new FileStream(filename, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    fw.Seek(num, SeekOrigin.Begin);
                    Console.WriteLine("Перезаписываем по позиции " + fw.Position);
                    bf.Serialize(fw, this);
                    Console.WriteLine("Перезаписали " + fw.Position);
                    result = true;
                }
                catch
                {
                }
                finally
                {
                    fw.Close();
                }
            }
            return result;
        }

        public static void TruncateBinary(string filename)
        {
            FileStream fw = new FileStream(filename, FileMode.Truncate);
            fw.Close();
        }

        public void NewData(Time time, string processPath)
        {
            this.timeSpend = Convert.ToInt64(time.ToSeconds());
            this.processPath = StringToByte(processPath);
        }

        public void ShowConsole()
        {
            Console.WriteLine("Дата начала трекинга: " + TimeFrom.ToString()
                + "\nИмя целевого процесса: " + ByteArrayToString(processName)
                + "\nПуть целевого процесса: " + ByteArrayToString(processPath)
                + "\nВремя трекера: " + timeSpend.ToString());
        }

        public DateTime TimeFrom
        {
            get { return new DateTime(timeFrom); }
        }

        public Time TimeIn
        {
            get { return new Time(Mode.Second ,Convert.ToUInt32(timeSpend)); }
        }

        public string ProcName
        {
            get { return ByteArrayToString(processName); }
            set { processName = StringToByte(value); }
        }
        public string ProcPath
        {
            get { return ByteArrayToString(processPath); }
        }
    }
}

