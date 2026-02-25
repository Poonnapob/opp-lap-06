using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    
    class teacher : Person
    {
        public string Major { get; set; }
        public string AcademicRank { get; set; }

        public teacher(string firstName, string lastName,
                          string phone, string email,
                          string major, string academicRank)
            : base(firstName, lastName, phone, email)
        {
            Major = major;
            AcademicRank = academicRank;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"position: {AcademicRank}  Branch: {Major}");
            Console.WriteLine($"type: teacher");
        }
    }

}

