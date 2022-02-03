using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TimeLib
{
    public enum Mode { Hour, Minute, Second };
    struct HMS
    {
        public uint hours;
        public uint minutes;
        public uint seconds;

        public uint ToSeconds()
        {
            return this.hours * 60 * 60 + minutes * 60 + seconds;
        }
    }
    public class Time
    {
        uint time; // in seconds
        Mode mode;

        public Time()
        {
            time = 0;
            mode = Mode.Second;
        }

        private HMS Normalize()
        {
            uint bufferT = time;
            uint hours = 0, minutes = 0, seconds = 0;
            while (bufferT > 3599)
            {
                bufferT -= 3600;
                hours++;
            }
            while (bufferT > 59)
            {
                bufferT -= 60;
                minutes++;
            }
            seconds = bufferT;

            HMS model;
            model.hours = hours;
            model.minutes = minutes;
            model.seconds = seconds;
            return model;
        }

        public Time(Mode mode, uint time)
        {
            if (mode == Mode.Second)
                this.time = time;
            else if (mode == Mode.Minute)
                this.time = time * 60;
            else if (mode == Mode.Hour)
                this.time = time * 60 * 60;

            Normalize();
            this.mode = mode;
        }

        public override string ToString()
        {
            HMS model = Normalize();
            string result;

            if ((int)(model.hours / 10) != 0)
                result = " [ " + model.hours + " : ";
            else
                result = " [ 0" + model.hours + " : ";

            if ((int)(model.minutes / 10) != 0)
                result += model.minutes + " : ";
            else
                result += "0" + model.minutes + " : ";

            if ((int)(model.seconds / 10) != 0)
                result += model.seconds + " ] ";
            else
                result += "0" + model.seconds + " ] ";

            return result;
        }

        public static Time operator +(Time obj, uint x)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time + x));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time + x * 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time + x * 3600));

            return null;
        }

        public static Time operator +(uint x, Time obj)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time + x));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time + x * 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time + x * 3600));

            return null;
        }

        public static Time operator -(Time obj, uint x)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time - x));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time - x * 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time - x * 3600));

            return null;
        }
        public static Time operator -(uint x, Time obj)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time - x));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time - x * 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time - x * 3600));

            return null;
        }

        public static Time operator +(Time obj, Time obj1)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time + obj1.time));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time + obj1.time));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time + obj1.time));

            return null;
        }

        public static Time operator -(Time obj, Time obj1)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, (obj.time - obj1.time));
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time - obj1.time));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time - obj1.time));

            return null;
        }

        public static Time operator ++(Time obj)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, obj.time++);
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time + 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time + 3600));

            return null;
        }

        public static Time operator --(Time obj)
        {
            if (obj.mode == Mode.Second)
                return new Time(Mode.Second, obj.time--);
            else if (obj.mode == Mode.Minute)
                return new Time(Mode.Minute, (obj.time - 60));
            else if (obj.mode == Mode.Hour)
                return new Time(Mode.Hour, (obj.time - 3600));

            return null;
        }

        public static bool operator >(Time obj, Time obj1)
        {
            if (obj.time > obj1.time)
                return true;
            else
                return false;
        }

        public static bool operator <(Time obj, Time obj1)
        {
            if (obj.time < obj1.time)
                return true;
            else
                return false;
        }

        public uint Hours
        {
            get
            {
                return Normalize().hours;
            }

            set
            {
                HMS model = Normalize();
                model.hours = value;
                time = model.ToSeconds();
            }
        }

        public uint Minutes
        {
            get
            {
                return Normalize().minutes;
            }

            set
            {
                HMS model = Normalize();
                model.minutes = value;
                time = model.ToSeconds();
            }
        }

        public uint Seconds
        {
            get
            {
                return Normalize().seconds;
            }

            set
            {
                HMS model = Normalize();
                model.seconds = value;
                time = model.ToSeconds();
            }
        }

        public void SetMode(Mode mode)
        {
            this.mode = mode;
        }

        public uint ToSeconds()
        {
            return Normalize().ToSeconds();
        }
    }
}
