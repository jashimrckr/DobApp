using System;
using System.Collections.Generic;
using System.Linq;

namespace DobApp
{
    public abstract class FamilyMember
    {
        public string Type { get; protected set; }
        public DateTime Dob { get; protected set; }
        public int TotalDays { get; protected set; }
        public Age Age { get; protected set; }

        public FamilyMember(string type, DateTime dob)
        {
            this.Type = type;
            this.Dob = dob;
            this.TotalDays = (DateTime.Now - dob).Days;
            this.Age = new Age(dob);
        }

        public static List<FamilyMember> SortMembers(List<FamilyMember> familyMemberList)
        {
            List<FamilyMember> sortedList = familyMemberList.OrderBy(o => o.TotalDays).ToList();
            return sortedList;
        }
    } 
}

