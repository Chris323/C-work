using System;
using System.Collections.Generic;

namespace VaccinationListLab2
{
    //Model Class
    class Vaccine
    {
        public string Name { get; set; }
        public int DosesAmount { get; set; }
        public int _daysBetweenDoses;
        public int TotalDosesRec { get; set; }

        public Vaccine(string name, int dosesAmount, int daysBetween, int totalDoses)
        {
            Name = name;
            DosesAmount = dosesAmount;
            _daysBetweenDoses = daysBetween;
            TotalDosesRec = totalDoses;
        }
        public int DaysBetweenDoses
        {
            get
            {
                return _daysBetweenDoses;
            }

            set
            {
                _daysBetweenDoses = value;
            }
        }
        public void AddTotalDosesRec(int addition)
        {
            TotalDosesRec += addition;
        }
    }

    //Database (also holds controller and view methods)
    class DataStore
    {
//        public List<Vaccine> vaccines = new List<Vaccine>();
        private Vaccine[] vaccines = new Vaccine[6];


        //"View" method for output
        public void VaccineListDisplay ()
        {
            bool contRunning = true;
            while (contRunning)
            {
                int count = 1;
                Console.WriteLine("Vaccine Management");
                Console.WriteLine("     Name           Doses Required         Days Between Doses            Total Doses Received");
                Console.WriteLine("----------------------------------------------------------------------------------------------");
                foreach (Vaccine vaccine in vaccines)
                {
                    if (vaccine == null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"{count})  {vaccine.Name}            {vaccine.DosesAmount}                       {vaccine.DaysBetweenDoses}                        {vaccine.TotalDosesRec}");
                        count++;
                    }
                }

                Console.WriteLine("a) Add Vaccine");
                Console.WriteLine("x) Close Application");
                Console.WriteLine("Please enter your choice:");

                string choice = Console.ReadLine();
                vaccineListChoice(count, choice);
                
            }
        }

        //"View" method for Input
        private void vaccineListChoice(int count, string choice)
        {
            if (choice == "1" || choice == "2" || choice == "3" || choice == "4" || choice == "5" || choice == "6")
            {
                int choiceAsNum = Int32.Parse(choice);
                choiceAsNum = choiceAsNum - 1;
                string name = vaccines[choiceAsNum].Name;
                Console.WriteLine();
                Console.WriteLine($"Vaccine Management - {name}");
                Console.WriteLine("Please enter how many new doses are received:");
                string input = Console.ReadLine();
                int amount = Int32.Parse(input);
                vaccineTotalChoice(choiceAsNum, amount);

                Console.WriteLine();
                VaccineListDisplay();

            }
            else if(choice == "a")
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the name of the Vaccine:");
                string nameInput = Console.ReadLine();

                Console.WriteLine("Please enter the amount of doses need for this vaccine:");
                string dAInput = Console.ReadLine();
                int doseAmountIn = Int32.Parse(dAInput);

                Console.WriteLine("Please enter the total doses recieved of this vaccine:");
                string tDInput = Console.ReadLine();
                int totalDosesRecIn = Int32.Parse(tDInput);

                if (doseAmountIn == 2)
                {
                    Console.WriteLine("Please enter the amount of days in between doses:");
                    string response = Console.ReadLine();
                    int dosesBetween = Int32.Parse(response);
                    addNewVaccine(count, nameInput, doseAmountIn, totalDosesRecIn, dosesBetween);
                }

                else
                {
                    addNewVaccine(count, nameInput, doseAmountIn, totalDosesRecIn);
                }

                Console.WriteLine();
                VaccineListDisplay();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }

        //"Controller" method for adding in dosage amount
        private void vaccineTotalChoice(int choice, int amount)
        {
            vaccines[choice].AddTotalDosesRec(amount);
        }

        //"Controller" for adding in new Vaccine
        private void addNewVaccine(int count, string Name, int doseAmount, int totalDosage, int dosesBetween = 0)
        {
            //int count;

            if (count <= 6)
            {
                vaccines[count - 1] = new Vaccine(Name, doseAmount, dosesBetween, totalDosage);
            }
            else
            {
                System.Environment.Exit(1);
            }
        }


    }
    //Driver class
    class Program
    {
        static void Main(string[] args)
        {
            DataStore storage = new DataStore();
            storage.VaccineListDisplay();
        }
    }
}
