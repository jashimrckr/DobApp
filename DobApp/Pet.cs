using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DobApp
{
    public class Pet : FamilyMember
    {
        public string Category { get; private set; }

        public Pet(string type, string category, DateTime dob) : base(type, dob)
        {
            this.Category = category;
        }

    }
}
