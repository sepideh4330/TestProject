using System.Collections.Generic;
using System.Threading.Tasks;
using Project.DomainClasses.Entities.Identities;

namespace Project.ServiceLayer.Contracts.Identities
{
   public interface ISiteStateService
    {
        Task<List<User>> GetOnlineUsersListAsync(int numbersToTake, int minutesToTake);
    }
}
