using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Records
    {
        public List<DateTime> records = new List<DateTime>(); //list of free time positions
        private DateTime _start;                              //start of the duty
        private DateTime _end;                                //end of the duty

        //constructor without parameters, default duty = 9:00-18:00
        public Records()
        {
            this._start = new DateTime(2020, 1, 1, 9, 0, 0);
            this._end = new DateTime(2020, 1, 1, 18, 0, 0);
            for (DateTime i = _start; i < _end; i.AddMinutes(12))  //12 minutes for every patient
            {
                records.Add(i);
            }
        }

        //constructor, 1 duty = 9:00-13:00, 2 duty = 13:00-17:00
        public Records(int duty)
        {
            if (duty == 1)
            {
                this._start = new DateTime(2020, 1, 1, 9, 0, 0);
                this._end = new DateTime(2020, 1, 1, 13, 0, 0);
            }
            else if (duty == 2)
            {
                this._start = new DateTime(2020, 1, 1, 13, 0, 0);
                this._end = new DateTime(2020, 1, 1, 17, 0, 0);
            }
            else
            {
                throw new ArgumentOutOfRangeException(" ---> There are only 1/2 duty!!! <--- ".ToUpper());
            }
            for (DateTime i = _start; i < _end; i = i.AddMinutes(12))
            {
                records.Add(i);
            }
        }

        //function of adding the weekend day
        public void Make_A_Weekend()
        {
            DateTime renull = new DateTime(2020, 1, 1, 0, 0, 0);
            for (int i = 0; i < 20; i++)
            {
                records[i] = renull;
            }
        }

        //funktion of making an appointment
        public void Appointment(DateTime time)
        {
            int ind = records.IndexOf(time);
            DateTime renull = new DateTime(2020, 1, 1, 0, 0, 0);
            if (records[ind] != renull)
            {
                records[ind] = renull;
            }
            else if (records[ind] == renull)        //Exception of attempt to record in busy time
            {
                throw new InvalidOperationException(" ---> This time is busy! <---".ToUpper());
            }
            else if (ind == -1)                     //Exception of time out of range recording
            {
                throw new InvalidOperationException(" ---> You entered a wrong time! <--- ".ToUpper());
            }
        }

        //function to output records (if the time is busy, output = " ")
        public void Show_records()
        {
            foreach (var item in records)
            {
                if (item.ToShortTimeString() == "00:00")
                {
                    Console.Write("     ");
                }
                else
                {
                    Console.Write(item.ToShortTimeString());
                }
                Console.Write("  ");
            }
            Console.WriteLine("\n");
        }
    }
}
