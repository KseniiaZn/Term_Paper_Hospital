using System;
using Hospital_Lib;

namespace Zinkova_Term_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Schedule[] Year = new Schedule[48];

            Schedule SHEDULE_18 = new Schedule(18);
            Year[18] = SHEDULE_18;

            //Create doctors:
            Family_Doctor Malaniuk_B_A = new Family_Doctor("Malaniuk B.A.", "therapist", new DateTime(1987, 3, 1, 0, 0, 0), "male", "+907 899 77 12", "malvaaamall@gmail.com");
            Family_Doctor Styryk_M_D = new Family_Doctor("Styryk M.D.", "physician", new DateTime(1979, 9, 30, 0, 0, 0), "male", "+905 009 71 34", "styryyyk@gmail.com");
            Family_Doctor Varova_I_A = new Family_Doctor("Varora I.A.", "internist", new DateTime(1990, 1, 17, 0, 0, 0), "female", "+907 102 13 44", "doc_varovava@gmail.com");
            Family_Doctor Tkach_P_R = new Family_Doctor("Tkach P.R.", "therapist", new DateTime(1988, 10, 22, 0, 0, 0), "male", "+908 321 78 90", "tkach-maron@gmail.com");
            Family_Doctor Petrenko_J_K = new Family_Doctor("Petrenko J.K.", "physician", new DateTime(1992, 12, 25, 0, 0, 0), "female", "+906 896 12 00", "penrenko.doc@gmail.com");

            //Create patients:
            Patient Savchuk_T_K = new Patient("Savchuk T.K.", new DateTime(1993, 10, 21), "female", "+380 951 57 08", "savatt@gmail.com", Malaniuk_B_A);
            Patient Maruk_P_F = new Patient("Maruk P.F.", new DateTime(1980, 12, 30), "male", "+380 978 02 011", "marukmar@gmail.com", Malaniuk_B_A);
            Patient Sarova_B_M = new Patient("Sarova B.M.", new DateTime(1997, 8, 24), "female", "+380 956 65 09", "0506sarovat@gmail.com", Malaniuk_B_A);
            Patient Zacharinkova_P_I = new Patient("Savchuk T.K.", new DateTime(1989, 01, 12), "female", "+380 93 55 90", "zaharart03@gmail.com", Malaniuk_B_A);
            Patient Kot_P_F = new Patient("Kot P.F.", new DateTime(1994, 9, 22), "male", "+380 951 57 08", "kot_1994@gmail.com", Malaniuk_B_A);

            //Open records of doctors for the next week, choose a duty, add weekends if it's necessary:
            Malaniuk_B_A.Open_Record(SHEDULE_18, 1);
            Malaniuk_B_A.Add_weekend(7);
            Styryk_M_D.Open_Record(SHEDULE_18, 2);
            Styryk_M_D.Add_weekend(7);
            Varova_I_A.Open_Record(SHEDULE_18, 1);
            Varova_I_A.Add_weekend(7);
            Tkach_P_R.Open_Record(SHEDULE_18, 1);
            Petrenko_J_K.Open_Record(SHEDULE_18, 2);

            //Add visits to medical cards of patients:
            Savchuk_T_K.Add_Entry(new DateTime(2019, 7, 30, 16, 48, 0), Tkach_P_R, "Headache complaints. Spasmodics have been prescribed.");
            Savchuk_T_K.Add_Entry(new DateTime(2019, 1, 20, 9, 43, 0), Malaniuk_B_A, "Scheduled inspection. Health is in perfect condition.");
            Savchuk_T_K.Add_Entry(new DateTime(2019, 2, 1, 10, 12, 0), Malaniuk_B_A, "Suspicion of the poisoning. Blood tests are recommended!");
            Savchuk_T_K.Add_Entry(new DateTime(2019, 2, 15, 9, 36, 0), Malaniuk_B_A, "Poisoning succrssfully treated.");
            Savchuk_T_K.Add_Entry(new DateTime(2020, 3, 4, 10, 36, 0), Styryk_M_D, "Medical check-up of the physician. Hospital closure.");

            //Add appointments to the doctor Malaniuk_B_A:
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 9, 12, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 9, 0, 0), Maruk_P_F);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 9, 24, 0), Kot_P_F);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 9, 36, 0), Sarova_B_M);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 9, 48, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 10, 12, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 10, 0, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 10, 24, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 10, 36, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 10, 48, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 11, 12, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 11, 0, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 11, 24, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 11, 36, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 11, 48, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 12, 12, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 12, 0, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 12, 24, 0), Zacharinkova_P_I);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 12, 36, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(1, new DateTime(2020, 1, 1, 12, 48, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(3, new DateTime(2020, 1, 1, 9, 00, 0), Kot_P_F);
            Malaniuk_B_A.Make_An_Appontment(3, new DateTime(2020, 1, 1, 11, 36, 0), Savchuk_T_K);
            Malaniuk_B_A.Make_An_Appontment(4, new DateTime(2020, 1, 1, 9, 24, 0), Sarova_B_M);
            Malaniuk_B_A.Make_An_Appontment(5, new DateTime(2020, 1, 1, 12, 36, 0), Zacharinkova_P_I);
            Malaniuk_B_A.Make_An_Appontment(5, new DateTime(2020, 1, 1, 12, 12, 0), Kot_P_F);
            Malaniuk_B_A.Make_An_Appontment(6, new DateTime(2020, 1, 1, 10, 0, 0), Kot_P_F);


            Styryk_M_D.Make_An_Appontment(3, new DateTime(2020, 1, 1, 15, 24, 0), Savchuk_T_K);
            Styryk_M_D.Make_An_Appontment(1, new DateTime(2020, 1, 1, 13, 36, 0), Sarova_B_M);
            Styryk_M_D.Make_An_Appontment(5, new DateTime(2020, 1, 1, 15, 0, 0), Zacharinkova_P_I);
            Styryk_M_D.Make_An_Appontment(3, new DateTime(2020, 1, 1, 16, 12, 0), Kot_P_F);
            Styryk_M_D.Make_An_Appontment(5, new DateTime(2020, 1, 1, 15, 12, 0), Kot_P_F);

            bool alive = true;
            while (alive)
            {
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("1. Show schedule \t\t 2. Doctors list  \t\t 3. Free appointments in the doctor's scedule");
                Console.WriteLine("4. Doctor's appointments\t 5. Doctor's patients\t\t 6. Patient's medical card");
                Console.WriteLine("7. Make an appointment \t\t 8. Exit");
                Console.Write("\nEnter number of Your choise: ");
                Console.ForegroundColor = color;
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());
                    int week = 1;
                    if (command == 1 || command == 3 || command == 4 || command == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Enter number of the week: ");
                        Console.ForegroundColor = color;
                        week = Convert.ToInt32(Console.ReadLine());
                    }
                    int doc_id = 1;
                    if (command == 3 || command == 4 || command == 5 || command == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Enter ID of the doctor: ");
                        Console.ForegroundColor = color;
                        doc_id = Convert.ToInt32(Console.ReadLine());
                    }
                    int pat_id = 1;
                    if (command == 6 || command == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Enter ID of the patient: ");
                        Console.ForegroundColor = color;
                        pat_id = Convert.ToInt32(Console.ReadLine());
                    }
                    DateTime userTime = new DateTime(2020, 1, 1, 0, 0, 0);
                    int day = 1;
                    if (command == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Please enter a time in format: h:m");
                        Console.ForegroundColor = color;
                        string dateString = Console.ReadLine();
                        int hours = Convert.ToInt32(dateString.Split(':')[0]);
                        int minutes = Convert.ToInt32(dateString.Split(':')[1]);

                        userTime = userTime.AddHours(hours);
                        userTime = userTime.AddMinutes(minutes);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Please enter a day: 1.Mon  2.Tue  3.Wed  4.Thu  5.Frd  6.Sat  7.Sun");

                        Console.ForegroundColor = color;
                        day = Convert.ToInt32(Console.ReadLine());
                    }
                    switch (command)
                    {
                        case 1:
                            Year[week].Show_Shedule(); //method of showing the shedule for enterd week
                            break;
                        case 2:
                            Schedule.Show_Doctors();   //static method, output list of all doctors
                            break;
                        case 3:                        //show personal timetable of entered doctor for entered week
                            Year[week].Find_Doctor_By_ID(doc_id).Show_doctor_timetable();
                            break;
                        case 4:                       //show appointments (patients) of entered doctor for entered week
                            Year[week].Find_Doctor_By_ID(doc_id).Show_doctor_appointments(week);
                            break;
                        case 5:                       //show the list of patients of entered doctor 
                            Year[18].Find_Doctor_By_ID(doc_id).Show_patients_list();
                            break;
                        case 6:                       //show the medical card (info + visits) of enterd patient
                            Schedule.cards_archive[pat_id].owner.Show_Card();
                            break;
                        case 7:                       //make an appointpent
                            Year[week].Find_Doctor_By_ID(doc_id).Make_An_Appontment(day, userTime, Year[week].Find_Patient_By_ID(pat_id));
                            Console.WriteLine("An appointment was successfully added!");
                            break;
                        case 8:                        //exit
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    //exception handling
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
