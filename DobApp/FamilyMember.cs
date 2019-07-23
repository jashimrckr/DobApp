using System;
using System.Collections.Generic;
using System.Linq;

namespace DobApp
{
    public class FamilyMember
    {
        public string Name { get; private set; }
        public DateTime Dob { get; private set; }
        public int TotalDays { get; private set; }
        public Age Age { get; private set; }

        public FamilyMember(string name, DateTime dob)
        {
            this.Name = name;
            this.Dob = dob;
            this.TotalDays = (DateTime.Now - dob).Days;
            this.Age = new Age(dob);

        }

        public static List<FamilyMember> SortMembers(List<FamilyMember> FamilyMemberList)
        {
            List<FamilyMember> sortedList = FamilyMemberList.OrderBy(o => o.TotalDays).ToList();
            return sortedList;
        }
    }

    
}

