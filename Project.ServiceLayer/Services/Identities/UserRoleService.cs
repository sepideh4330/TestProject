using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<UserRole> _userRoles;

        public UserRoleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _userRoles = _unitOfWork.Set<UserRole>();
        }

        public async Task<List<string>> FindUserRoleEnNamesAsync(Guid userId)
        {
            return await _userRoles.AsNoTracking().Include(d => d.Role).Where(d => d.UserId == userId).Select(d => d.Role.Name).ToListAsync();
        }
    }
}
