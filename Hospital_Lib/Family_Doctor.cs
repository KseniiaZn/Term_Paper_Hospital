using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Family_Doctor : Employee, Ipay                                //inherited from employee, assigned for interface Ipay
    {
        public List<Patient> doc_patients = new List<Patient>();        //list of patients
        public int _patients_qantity;
        public List<Records> free_rec = new List<Records>();            //list of free time for records
        public List<List<String>> busy_rec = new List<List<String>>();  //list of recoords
        public List<String> row = new List<String>();
        private string _specialty;
        private decimal _doc_salary = 5300;                             //standart salary, without bonuses
        private Nurse doc_nurse;                                        //a nurse of the doctor

        public string Get_specialty => _specialty;                      //Lambda expressions for getting specialty

        public delegate bool IsBusyDayEvent(Records rec);               //delegate to a function like 'bool <name>(Records)'
        public event IsBusyDayEvent IsBusy = null;                      //define an event using delegate

        public delegate bool Is2000Patients();                          //one more delegate
        public event Is2000Patients Raise_The_Salary = null;            //event for bonus conting


        private static string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Frd", "Sat", "Sun" };
        private int numder_of_patients;                    //for bonus counting & exception (Doctor can't has > 2000 patients)

        //funktion for event, detect when the day is complitely busy
        public bool Is_Busy(Records rec)
        {
            DateTime renull = new DateTime(2020, 1, 1, 0, 0, 0);
            foreach (var item in rec.records)
            {
                if (item != renull)
                {
                    return false;
                }
            }
            return true;
        }

        //funktion for event, increases salary if the doctor has more than 2000 people in list of his patients
        public bool Is_2000_Patients()
        {
            if (doc_patients.Count > 2000)
            {
                _doc_salary = 6300;
                return true;
            }
            return false;
        }

        //calling the base constructor + assignment for 2 events + specialty
        public Family_Doctor(string name, string specialty, DateTime date_of_birth, string gender, string phone_number, string email)
            : base(name, date_of_birth, gender, phone_number, email)
        {
            this._specialty = specialty;
            this.IsBusy += this.Is_Busy;
            this.Raise_The_Salary += this.Is_2000_Patients;
            this.doc_nurse = null;
        }

        //fuktion to open the record for a week, to add the doctor to the week timetable
        public void Open_Record(Schedule schedule, int duty)
        {
            for (int i = 0; i < 7; i++)
            {
                Records new_day = new Records(duty);
                row = new List<String>();
                free_rec.Add(new_day);
                busy_rec.Add(row);
            }
            schedule.Add_Doctor(this, this.free_rec);
        }

        //funktion to add new patient to the doctor's list of patients
        public void Add_Patient(Patient patient)
        {
            if (numder_of_patients <= 2000)
            {
                doc_patients.Add(patient);
                this.numder_of_patients += 1;
            }
            else throw new ArgumentOutOfRangeException("2,000 patients already assigned to the doctor!");
        }

        //funktion to add new appointpent to doctor's timetable 
        public void Make_An_Appontment(int day, DateTime time, Patient patient)
        {
            day -= 1;    //user gives a numder of the day, not index
            if (day >= 0 || day < 8)
            {
                free_rec[day].Appointment(time);
                this.busy_rec[day].Add(time.ToShortTimeString() + " " + patient.Get_Name + "(id = " + patient.Get_ID + ")");
                busy_rec[day].Sort();
            }
            else
                throw new ArgumentOutOfRangeException(" ---> You enterd a wrong day of the week! <--- ");
        }

        //funktion to add a weekend day to doctor's timetable, if it's necessary
        public void Add_weekend(int day)
        {
            day -= 1;
            if (day >= 0 || day < 8)
            {
                free_rec[day].Make_A_Weekend();
                this.busy_rec[day].Add("weekend!".ToUpper());
            }
            else
                throw new ArgumentOutOfRangeException(" ---> You enterd a wrong day of the week! <--- ");
        }

        //function to output appointmets (day, time, patients, IDs of patients)
        public void Show_doctor_appointments(int week)
        {
            Console.WriteLine("appointments of ".ToUpper() + this._name + " (week " + week + ")\n");
            for (int i = 0; i < 7; i++)
            {
                Console.Write(days[i].ToUpper() + ": \n");
                foreach (var item in busy_rec[i])
                {
                    Console.Write(item + "\n");
                }
                Console.WriteLine();
            }
        }

        //function to output personal timetable of the doctor (only free time, weekends, complitely busy days)
        public void Show_doctor_timetable()
        {
            string line = new string('=', 53);
            Console.WriteLine(line + " Timetable of the doctor " + this.Get_Name + line);
            int j = 0;
            foreach (var item in this.free_rec)
            {
                Console.Write(days[j++] + ":  ");
                bool busy_day = false;
                if (IsBusy != null)
                {                        //if event != null, we are calling this event
                    busy_day = IsBusy(item);
                }
                if (busy_day)
                {                              //if it's a busy day or weekend
                    Console.WriteLine("\tfull day!\n".ToUpper());
                }
                else
                {
                    item.Show_records();
                }
            }
        }

        //function of output all the patients of this doctor
        public void Show_patients_list()
        {
            Console.WriteLine("\tList of patients of doctor ".ToUpper() + this._name.ToUpper());
            Console.WriteLine("\nID  Name\tPhone\t\tEmail\n");
            foreach (var item in doc_patients)
            {
                Console.WriteLine(item.Get_ID + " " + item.Get_Name + "\t" + item.Get_phone_number + "\t" + item.Get_email);
            }
        }
        private void register_nurse(Nurse nurse)
        {
            this.doc_nurse = nurse;
        }
        //bonus counting as requires the interface
        decimal Ipay.Count_Bonus()
        {
            decimal bonus = _patients_qantity * 2;
            return bonus;
        }

        //salary counting as requires the interface
        decimal Ipay.To_pay()
        {
            Raise_The_Salary?.Invoke();
            decimal salary = _doc_salary + ((Ipay)this).Count_Bonus();
            return salary;
        }
    }
}
