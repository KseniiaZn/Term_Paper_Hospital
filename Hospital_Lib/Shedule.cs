using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Schedule
    {
        private int _week_number;
        public List<List<Records>> week = new List<List<Records>>();                  //list of all records for this week
        public List<Family_Doctor> week_doctors = new List<Family_Doctor>();          //list of doctors, which are on duty this week
        static public List<Family_Doctor> all_doctors = new List<Family_Doctor>();    //list of all doctors
        static public Medical_Card[] cards_archive = new Medical_Card[10000];         //archive of all medical cards
        private int _doctors_quatnity;
        private static string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Frd", "Sat", "Sun" };

        public Medical_Card this[int index]  //indexer by archive of cards
        {                                    //it's useful, because ID of the card = ID of owner
            get
            {
                if (index != -1)
                {
                    return cards_archive[index];
                }
                throw new ArgumentNullException(" ---> There is no patient with this ID! <--- ");
            }
            set
            {
                cards_archive[index] = value;
            }
        }

        //constructor of creating a new week
        public Schedule(int week)
        {
            this._doctors_quatnity = 0;
            this._week_number = week;
        }

        //function of adding doctor to this week
        public void Add_Doctor(Family_Doctor doctor, List<Records> free_rec)
        {
            week_doctors.Add(doctor);
            week.Add(free_rec);
            this._doctors_quatnity += 1;
            if (all_doctors.IndexOf(doctor) == -1)
            {
                all_doctors.Add(doctor);
            }
        }

        //function of getting doctor by ID whith exeption when there is no doctor with given ID
        public Family_Doctor Find_Doctor_By_ID(int id)
        {
            try
            {
                foreach (var item in this.week_doctors)
                {
                    if (item.Get_ID == id)
                    {
                        return item;
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(" ---> There is no doctor with this ID! <--- ".ToUpper());
            }
        }

        //function of getting patient by ID whith exeption when there is no patient with given ID
        public Patient Find_Patient_By_ID(int id)
        {
            try
            {
                foreach (var item in all_doctors)
                {
                    foreach (var item_2 in item.doc_patients)
                    {
                        if (item_2.Get_ID == id)
                        {
                            return item_2;
                        }
                    }
                }
                throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(" ---> There is no patient with this ID! <--- ".ToUpper());
            }
        }

        //function to show the shedule with appointments for this week
        public void Show_Shedule()
        {
            string line = new string('=', 62);                  //the line of "=" for formatting
            Console.WriteLine("\n  " + line + "SHEDULE week " + this._week_number + line + "\n");
            for (int i = 0; i < this._doctors_quatnity; i++)
            {
                Console.WriteLine("\n" + line + "\t  " + week_doctors[i].Get_Name + "\t" + line);
                int j = 0;
                foreach (var item in week[i])
                {
                    Console.Write(days[j++] + ":  ");
                    item.Show_records();
                }
            }

        }

        //function to show the list of all doctors in hospital
        static public void Show_Doctors()
        {
            Console.WriteLine("\n\tOUR CURRENT DOCTORS:");
            Console.WriteLine("\nID   name\tspecialty\temail\t\t\tphone\n");
            foreach (var item in all_doctors)
            {
                Console.WriteLine(item.Get_ID + " " + item.Get_Name + "\t" + item.Get_specialty + "\t" + item.Get_email + "\t" + item.Get_phone_number);
            }
        }
    }
}
