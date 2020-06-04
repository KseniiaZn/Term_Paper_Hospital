using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Lib
{
    public class Medical_Card
    {
        public int medicalCardID;                       //unique ID, which = owner's ID
        public Patient owner;
        public List<Entry> entries = new List<Entry>();  //list of entries of the owner with time, doctors, diagnosis

        //constructor, gives a card the same ID as has the patient + add card to the archive
        public Medical_Card(Patient patient)
        {
            this.owner = patient;
            this.medicalCardID = patient.Get_ID;
            Schedule.cards_archive[patient.Get_ID] = this;
        }

        //function of adding an entry to the medical card:
        public void Add(Entry entry)
        {
            entries.Add(entry);
        }

        //output of thr medical card (visits)
        public void Show_Medical_Card()
        {
            foreach (var item in entries)
            {
                Console.Write(item.date.ToString() + "\t" + item.doctor.Get_Name + "\t" + item.diagnosis + "\n");
            }
        }
    }
}
