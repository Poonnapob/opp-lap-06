using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    
    class public_Person : Person
    {
        public string Workplace { get; set; }
        public string Position { get; set; }

        public public_Person(string firstName, string lastName,
                             string phone, string email,
                             string workplace, string position)
            : base(firstName, lastName, phone, email)
        {
            Workplace = workplace;
            Position = position;
        }

        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine($"location workplace: {Workplace}  position of work: {Position}");
            Console.WriteLine($"type: public person");
        }
    }
}

