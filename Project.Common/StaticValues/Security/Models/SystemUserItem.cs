namespace Project.Common.StaticValues.Security.Models
{
    public class SystemUserItem
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Gender { get; set; }

        public string Email { get; set; }

        public string GroupNameEn { get; set; }

        public SystemUserItem(string username, string password, string  firstName, string lastName, int gender, string email, string groupNameEn)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Email = email;
            GroupNameEn = groupNameEn;
        }

    }
}
