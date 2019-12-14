using Project.Common.Extensions;
using Project.Common.Utilities.SequentialGuid;
using Project.DomainClasses.Entities.Identities;

namespace Project.DomainClasses.Extensions.Identities
{
    public static class UserExtensions
    {
        public static void CleanEmailToken(this User user)
        {
            user.EmailToken = null;
            user.EmailTokenLifespanDateTimeOn = null;
        }
    }
}
