using System;
using System.Threading.Tasks;
using Project.DomainClasses.Entities.Identities;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUsedPasswordService
    {
        Task<bool> IsPreviouslyUsedPasswordAsync(User user, string newPassword);
        Task AddToUsedPasswordsListAsync(User user);
        Task<bool> IsLastUserPasswordTooOldAsync(Guid userId);
        Task<DateTimeOffset?> GetLastUserPasswordChangeDateAsync(Guid userId);
    }
}
