using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    public class Person : FamilyMember
    {
        public string Name { get; private set; }

        public Person(string type, string name, DateTime dob) : base(type, dob)
        {
            this.Name = name;
        }
    }
}
