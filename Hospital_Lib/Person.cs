using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public abstract class Person               //abstract class for all people
    {
        protected string _name;
        protected DateTime _date_of_birth;
        protected string _gender;
        protected string _phone_number;
        protected string _email;
        public string Get_Name => _name;   //Lambda expressions for getting field values
        public string Get_email => _email;
        public string Get_phone_number => _phone_number;

        //constructor for every person:
        public Person(string name, DateTime date_of_birth, string gender, string phone_number, string email)
        {
            this._name = name;
            this._date_of_birth = date_of_birth;
            this._gender = gender;
            this._phone_number = phone_number;
            this._email = email;
        }
    }
}
