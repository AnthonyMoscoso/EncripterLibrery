using System;
using System.Collections.Generic;
using System.Text;

namespace EncripterTest
{
    public class Users
    {
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}\nPass: {Pass}\nPhone: {Phone}\nEmail: {Email}";
        }
    }
}
