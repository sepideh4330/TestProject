using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class RoleService : RoleManager<Role>, IRoleService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityErrorDescriber _identityErrorDescriber;
        private readonly ILookupNormalizer _lookupNormalizer;
        private readonly ILogger<RoleService> _logger;
        private readonly IEnumerable<IRoleValidator<Role>> _roleValidators;
        private readonly IRoleStoreService _roleStoreService;
        private readonly DbSet<Role> _roles;
        private readonly DbSet<User> _users;

        public RoleService(
            IRoleStoreService roleStoreService,
            IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer lookupNormalizer,
            IdentityErrorDescriber errors,
            ILogger<RoleService> logger,
            IHttpContextAccessor httpContextAccessor,
            IUnitOfWork unitOfWork) :
            base((RoleStore<Role, ApplicationDbContext, Guid, UserRole, RoleClaim>)roleStoreService, roleValidators, lookupNormalizer, errors, logger)
        {
            _roleStoreService = roleStoreService;
            _roleStoreService.CheckArgumentIsNull(nameof(_roleStoreService));

            _roleValidators = roleValidators;
            _roleValidators.CheckArgumentIsNull(nameof(_roleValidators));

            _lookupNormalizer = lookupNormalizer;
            _lookupNormalizer.CheckArgumentIsNull(nameof(_lookupNormalizer));

            _identityErrorDescriber = errors;
            _identityErrorDescriber.CheckArgumentIsNull(nameof(_identityErrorDescriber));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _httpContextAccessor = httpContextAccessor;
            _httpContextAccessor.CheckArgumentIsNull(nameof(_httpContextAccessor));

            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _roles = _unitOfWork.Set<Role>();
            _users = _unitOfWork.Set<User>();
        }
    }
}
