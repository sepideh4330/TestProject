using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class RoleStoreService : RoleStore<Role, ApplicationDbContext, Guid, UserRole, RoleClaim>, IRoleStoreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityErrorDescriber _identityErrorDescriber;

        public RoleStoreService(
            IUnitOfWork unitOfWork,
            IdentityErrorDescriber identityErrorDescriber)
            : base((ApplicationDbContext)unitOfWork, identityErrorDescriber)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _identityErrorDescriber = identityErrorDescriber;
            _identityErrorDescriber.CheckArgumentIsNull(nameof(_identityErrorDescriber));
        }
    }
}
