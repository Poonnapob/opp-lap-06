using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    class Student : Person
    {
        public string StudentId { get; set; }
        public string Major { get; set; }

        public Student(string firstName, string lastName,
                       string phone, string email,
                       string studentId, string major)
            : base(firstName, lastName, phone, email) 
        {
            StudentId = studentId;
            Major = major;
        }

       
        public override void ShowInfo()
        {
            base.ShowInfo(); 
            Console.WriteLine($"Id: {StudentId}  Branch: {Major}");
            Console.WriteLine($"type: student");
        }
    }
}

