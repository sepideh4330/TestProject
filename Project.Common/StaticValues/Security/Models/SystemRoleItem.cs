namespace Project.Common.StaticValues.Security.Models
{
    public class SystemRoleItem
    {
        public string Name { get; set; }

        public string NameFa { get; set; }

        public string Description { get; set; }

        public int Type { get; set; }

        public string ReferenceRoleName { get; set; }

        public int Category { get; set; }

        public SystemRoleItem(string name, string nameFa, string description, int type, string referenceRoleName, int category)
        {
            Name = name;
            NameFa = nameFa;
            Description = description;
            Type = type;
            ReferenceRoleName = referenceRoleName;
            Category = category;
        }
    }
}
