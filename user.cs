using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    using System.Collections.Generic;

   
    class TrainingSystem
    {
        List<Person> participants = new List<Person>(); 
        List<Trainer> trainers = new List<Trainer>(); 

       
        public void AddStudent()
        {
            Console.Write("name: ");
            string fn = Console.ReadLine();
            Console.Write("lastname: ");
            string ln = Console.ReadLine();
            Console.Write("phone: ");
            string ph = Console.ReadLine();
            Console.Write("Email: ");
            string em = Console.ReadLine();
            Console.Write("student id: ");
            string sid = Console.ReadLine();
            Console.Write("Branch: ");
            string maj = Console.ReadLine();

            Student s = new Student(fn, ln, ph, em, sid, maj);
            participants.Add(s);
            Console.WriteLine("Successfully add students");
        }

    
        public void AddInstructor()
        {
            Console.Write("name: ");
            string fn = Console.ReadLine();
            Console.Write("lastname: ");
            string ln = Console.ReadLine();
            Console.Write("phone: ");
            string ph = Console.ReadLine();
            Console.Write("Email: ");
            string em = Console.ReadLine();
            Console.Write("Branch: ");
            string maj = Console.ReadLine();

            Console.WriteLine("position: 1=teacher  2=Assistant Professor  3=Associate Assistant Professor  4=Professor");
            Console.Write("choose: ");
            string choice = Console.ReadLine();

           
            string rank = "teacher";
            if (choice == "2") rank = "Assistant Professor";
            else if (choice == "3") rank = "Associate Assistant Professor";
            else if (choice == "4") rank = "Professor";

            teacher ins = new teacher(fn, ln, ph, em, maj, rank);
            participants.Add(ins);
            Console.WriteLine("Successfully add teacher");
        }

      
        public void AddGeneralPerson()
        {
            Console.Write("name: ");
            string fn = Console.ReadLine();
            Console.Write("lastname: ");
            string ln = Console.ReadLine();
            Console.Write("phone: ");
            string ph = Console.ReadLine();
            Console.Write("Email: ");
            string em = Console.ReadLine();
            Console.Write("location of work: ");
            string wp = Console.ReadLine();
            Console.Write("position: ");
            string pos = Console.ReadLine();

            public_Person gp = new public_Person(fn, ln, ph, em, wp, pos);
            participants.Add(gp);
            Console.WriteLine("Successfully add public person");
        }

        public void AddTrainer()
        {
            Console.WriteLine("\n-- List of trinner --");

            List<Person> eligible = new List<Person>();
            int i = 1;

            foreach (Person p in participants)
            {
                if (p is teacher || p is public_Person)
                {
                    Console.WriteLine($"{i}. {p.FirstName} {p.LastName}");
                    eligible.Add(p);
                    i++;
                }
            }

            if (eligible.Count == 0)
            {
                Console.WriteLine("There is no one available to be a trinner");
                return;
            }

            int index;
            while (true)
            {
                Console.Write("choose number: ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input was empty. Please enter a numeric choice.");
                    continue;
                }
                input = input.Trim();
                if (!int.TryParse(input, out int selection))
                {
                    Console.WriteLine("Invalid number. Please enter a numeric choice.");
                    continue;
                }
                if (selection < 1 || selection > eligible.Count)
                {
                    Console.WriteLine($"Please choose a number between 1 and {eligible.Count}.");
                    continue;
                }
                index = selection - 1;
                break;
            }

            Console.Write("Expertise: ");
            string spec = Console.ReadLine() ?? string.Empty;

            Trainer t = new Trainer(eligible[index], spec);
            if (t.BasePerson != null)
            {
                trainers.Add(t);
                Console.WriteLine("Successfully add trinner");
            }
        }

        public void ShowParticipants()
        {
            Console.WriteLine("\n========== list of couse ==========");

            if (participants.Count == 0)
            {
                Console.WriteLine("don't have person registor");
                return;
            }

            int i = 1;
            foreach (Person p in participants)
            {
                Console.WriteLine($"\n--- No. {i++} ---");
                p.ShowInfo();
            }

            Console.WriteLine($"\ntogether: {participants.Count} person");
        }

       
        public void ShowTrainers()
        {
            Console.WriteLine("\n========== list name of trinner ==========");

            if (trainers.Count == 0)
            {
                Console.WriteLine("don't have trinner");
                return;
            }

            int i = 1;
            foreach (Trainer t in trainers)
            {
                Console.WriteLine($"\n--- trinner No. {i++} ---");
                t.ShowInfo();
            }

            Console.WriteLine($"\ntogether: {trainers.Count} person");
        }

        
        public void ApproveResult()
        {
            if (trainers.Count == 0)
            {
                Console.WriteLine("There are no trinner in the system.");
                return;
            }

            Console.WriteLine("\n-- choose trinner --");
            for (int i = 0; i < trainers.Count; i++)
                Console.WriteLine($"{i + 1}. {trainers[i].BasePerson.FirstName} {trainers[i].BasePerson.LastName}");

            int tIndex = ReadSelection("choose trainer: ", trainers.Count);

            if (participants.Count == 0)
            {
                Console.WriteLine("There are no participants in the system.");
                return;
            }

            Console.WriteLine("\n-- Select trainees --");
            for (int i = 0; i < participants.Count; i++)
                Console.WriteLine($"{i + 1}. {participants[i].FirstName} {participants[i].LastName}");

            int pIndex = ReadSelection("choose participant: ", participants.Count);

            trainers[tIndex].ApproveResult(participants[pIndex]);
        }

        private int ReadSelection(string prompt, int maxInclusive)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Input was empty. Please enter a number.");
                    continue;
                }

                if (!int.TryParse(input.Trim(), out int sel))
                {
                    Console.WriteLine("Invalid number. Please enter digits only.");
                    continue;
                }

                if (sel < 1 || sel > maxInclusive)
                {
                    Console.WriteLine($"Please choose a number between 1 and {maxInclusive}.");
                    continue;
                }

                return sel - 1; // convert to zero-based index
            }
        }
    }
}

