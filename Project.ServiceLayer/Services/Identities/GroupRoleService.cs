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
    public class GroupRoleService : IGroupRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<GroupRole> _groupRoles;

        public GroupRoleService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _groupRoles = _unitOfWork.Set<GroupRole>();
        }

        public async Task<List<string>> FindUserRoleEnNamesAsync(Guid groupId)
        {
            return await _groupRoles.AsNoTracking().Include(d => d.Role).Where(d => d.GroupId == groupId)
                       .Select(d => d.Role.Name).ToListAsync();
        }
    }
}
