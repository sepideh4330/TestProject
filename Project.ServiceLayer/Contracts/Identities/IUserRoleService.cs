using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.ServiceLayer.Contracts.Identities
{
    public interface IUserRoleService
    {
        Task<List<string>> FindUserRoleEnNamesAsync(Guid userId);
    }
}
