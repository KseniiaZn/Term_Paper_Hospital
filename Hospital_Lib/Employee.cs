using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public abstract class Employee : Person         //inherited from person
    {
        private int _employee_ID;            //unique ID of the stuff
        static int counter;                  //static counter to controll uniqueness of the ID

        public int Get_ID => _employee_ID;   //Lambda expressions for getting ID

        //calling the base constructor + assignment of ID
        public Employee(string name, DateTime date_of_birth, string gender, string phone_number, string email)
            : base(name, date_of_birth, gender, phone_number, email)
        {
            this._employee_ID = ++counter;
        }
    }
    interface Ipay //interface of the payrolling
    {
        decimal To_pay();
        decimal Count_Bonus();
    }
}
