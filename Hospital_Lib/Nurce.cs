using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    class Nurse : Employee, Ipay                        //inherited from employee, assigned for interface Ipay
    {
        private Family_Doctor doctor;                   //nurce's doctor
        static private decimal _nurse_salary = 3200;    //standart salary, without bonuses

        //calling the base constructor 
        public Nurse(string name, DateTime date_of_birth, string gender, string phone_number, string email)
            : base(name, date_of_birth, gender, phone_number, email)
        {
        }

        //calling the base constructor  + assign thenurce to a doctor
        public Nurse(string name, DateTime date_of_birth, string gender, string phone_number, string email, Family_Doctor doctor)
            : base(name, date_of_birth, gender, phone_number, email)
        {
            this.doctor = doctor;
        }

        //salary counting as requires the interface
        decimal Ipay.To_pay()
        {
            decimal salary = _nurse_salary + ((Ipay)this).Count_Bonus();
            return salary;
        }

        //bonus counting as requires the interface
        decimal Ipay.Count_Bonus()
        {
            decimal bonus = (((Ipay)doctor).Count_Bonus() / 2);
            return bonus;
        }
    }
}
