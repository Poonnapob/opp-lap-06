using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            TrainingSystem system = new TrainingSystem();

            bool run = true;
            while (run)
            {
                Console.WriteLine("\n============================");
                Console.WriteLine("   oop couse");
                Console.WriteLine("============================");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add teacher");
                Console.WriteLine("3. Add public person");
                Console.WriteLine("4. Add trinner");
                Console.WriteLine("5. Show list of participants");
                Console.WriteLine("6. Show the list of trinner");
                Console.WriteLine("7. Approve training results");
                Console.WriteLine("0. Exit");
                Console.Write("choose: ");

                string choice = Console.ReadLine();
                Console.WriteLine(); // บรรทัดว่าง

                switch (choice)
                {
                    case "1": system.AddStudent(); break;
                    case "2": system.AddInstructor(); break;
                    case "3": system.AddGeneralPerson(); break;
                    case "4": system.AddTrainer(); break;
                    case "5": system.ShowParticipants(); break;
                    case "6": system.ShowTrainers(); break;
                    case "7": system.ApproveResult(); break;
                    case "0": run = false; break;
                    default:
                        Console.WriteLine(" Please select menu 0-7");
                        break;
                }
            }

            Console.WriteLine("End sytemp");
        }
    }
}
    

