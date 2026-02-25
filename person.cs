using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opp_lap_06
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Constructor
        public Person(string firstName, string lastName, string phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        // แสดงข้อมูลพื้นฐาน
        public virtual void ShowInfo()
        {
            Console.WriteLine($"ชื่อ: {FirstName} {LastName}");
            Console.WriteLine($"โทร: {Phone}  Email: {Email}");
        }
    }
}
