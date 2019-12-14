using System.Collections.Generic;

namespace Project.Common.StaticValues.Security.Models
{
    public class SystemGroupItem
    {
        public string NameEn { get; set; }

        public string NameFa { get; set; }

        public string Description { get; set; }

        public List<string> RoleNames { get; }

        public int Category { get; set; }

        public SystemGroupItem(string nameEn, string nameFa, string description, List<string> roleNames, int category)
        {
            NameEn = nameEn;
            NameFa = nameFa;
            Description = description;
            RoleNames = roleNames;
            Category = category;
        }
    }
}