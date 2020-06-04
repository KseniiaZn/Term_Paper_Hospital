using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Entry    //a short class to simplify the story of visits in medical card
    {
        public int medical_Card_ID;
        public DateTime date;
        public Family_Doctor doctor;
        public string diagnosis;

        //constructor to fill all fields of the visit
        public Entry(int medical_Card_ID, DateTime date, Family_Doctor doctor, string diagnosis)
        {
            this.medical_Card_ID = medical_Card_ID;
            this.date = date;
            this.doctor = doctor;
            this.diagnosis = diagnosis;
        }
    }
}
