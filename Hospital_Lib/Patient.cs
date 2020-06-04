using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Patient : Person
    {
        private int _patient_ID;
        static int counter;                    //counter to controll automatic assignment of a unique ID
        private Family_Doctor Doctor;
        private Medical_Card Card;             //medical card 
        public int Get_ID => _patient_ID;      //lambda expression for getting ID

        //calling the base constructor
        public Patient(string name, DateTime date_of_birth, string gender, string phone_number, string email)
            : base(name, date_of_birth, gender, phone_number, email)
        {
        }

        /*calling the base constructor, assignment of the  patient_ID, Doctor, adding a patient 
        to the doctor's list of patients, starting a medical card*/
        public Patient(string name, DateTime date_of_birth, string gender, string phone_number, string email, Family_Doctor Doctor)
        : base(name, date_of_birth, gender, phone_number, email)
        {
            this._patient_ID = counter++;
            this.Doctor = Doctor;
            Doctor.Add_Patient(this);
            Doctor._patients_qantity++;
            Card = new Medical_Card(this);
        }

        //function of adding the information about visit to the medical card
        public void Add_Entry(DateTime date, Family_Doctor doctor, string diagnosis)
        {
            Entry new_entry = new Entry(_patient_ID, date, doctor, diagnosis);
            Card.Add(new_entry);
        }

        //function of output of the medical card (info about the patient)
        public void Show_Card()
        {
            Console.WriteLine("\tMEDICAL CARD OF " + this._name + ":\n\nGender: \t" + this._gender + "\nBirthday:\t" +
                this._date_of_birth.ToShortDateString() + "\nPhone number:  " + this._phone_number + "\nEmail:\t\t" + this._email +
                "\nFamily doctor:  " + this.Doctor.Get_Name + "\nDoctor's ID:    " + this.Doctor.Get_ID + "\n\n\tLIST OF VISITS:\n\nDate\t\t\tDoctor\t\tDiagnosis\n");
            Card.Show_Medical_Card();
        }
    }
}
