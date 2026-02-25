using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{


    class Trainer
    {
        public Person BasePerson { get; set; }
        public string Specialty { get; set; } 

        public Trainer(Person person, string specialty)
        {
       
            if (person is teacher || person is public_Person)
            {
                BasePerson = person;
                Specialty = specialty;
            }
            else
            {
                Console.WriteLine("! Students are not allowed to be trinner. !");
            }
        }

        // วิทยากรดำเนินการอบรม
        public void ConductTraining(string courseName)
        {
            Console.WriteLine($"trinner [{BasePerson.FirstName} {BasePerson.LastName}]");
            Console.WriteLine($"  Training in progress: {courseName}");
        }

        // วิทยากรอนุมัติผล
        public void ApproveResult(Person participant)
        {
            Console.WriteLine($" trinner [{BasePerson.FirstName} {BasePerson.LastName}]");
            Console.WriteLine($"   Approve the results: {participant.FirstName} {participant.LastName}");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"trinner: {BasePerson.FirstName} {BasePerson.LastName}");
            Console.WriteLine($"Expertise: {Specialty}");

          
            if (BasePerson is teacher ins)
                Console.WriteLine($"position: {ins.AcademicRank}  Branch: {ins.Major}");
            else if (BasePerson is public_Person gp)
                Console.WriteLine($"location: {gp.Workplace}  position: {gp.Position}");
        }
    }
}
