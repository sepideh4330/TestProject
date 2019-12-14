using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.Common.StaticValues.Security;
using Project.Common.StaticValues.Security.Models;
using Project.Common.Utilities.SequentialGuid;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.DomainClasses.Enums.Business.Shared;
using Project.DomainClasses.Enums.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class IdentityDataInitializerService : IIdentityDataInitializerService
    {
        private readonly IOptionsSnapshot<SiteSettings> _options;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityService _securityService;
        private readonly IUserService _userService;
        private readonly ILogger<IdentityDataInitializerService> _logger;
        private readonly IRoleService _roleService;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly DbSet<User> _users;
        private readonly DbSet<UserRole> _userRoles;
        private readonly DbSet<Role> _roles;
        private readonly DbSet<Group> _groups;
        private readonly DbSet<GroupRole> _groupRoles;

        public IdentityDataInitializerService(
            IUnitOfWork unitOfWork,
            ISecurityService securityService,
            IUserService userService,
            IServiceScopeFactory scopeFactory,
            IRoleService roleService,
            ILookupNormalizer keyNormalizer,
            IOptionsSnapshot<SiteSettings> options,
            ILogger<IdentityDataInitializerService> logger
        )
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(_userService));

            _scopeFactory = scopeFactory;
            _scopeFactory.CheckArgumentIsNull(nameof(_scopeFactory));

            _roleService = roleService;
            _roleService.CheckArgumentIsNull(nameof(_roleService));

            _keyNormalizer = keyNormalizer;
            _keyNormalizer.CheckArgumentIsNull(nameof(_keyNormalizer));

            _options = options;
            _options.CheckArgumentIsNull(nameof(_options));

            _logger = logger;
            _logger.CheckArgumentIsNull(nameof(_logger));

            _users = _unitOfWork.Set<User>();
            _roles = _unitOfWork.Set<Role>();
            _groups = _unitOfWork.Set<Group>();
            _groupRoles = _unitOfWork.Set<GroupRole>();
            _userRoles = _unitOfWork.Set<UserRole>();
        }

        public void SeedRoles()
        {
            var lastRoles = _roles.AsNoTracking().ToList();
            List<SystemRoleItem> generatorRoles = new List<SystemRoleItem>();
            var generalRoles = SystemRoles.GetAll;

            foreach (var role in generalRoles)
            {
                generatorRoles.Add(role);
            }
            if (!generatorRoles.Any())
            {
                foreach (var groupRole in _groupRoles.ToList())
                {
                    _groupRoles.Remove(groupRole);
                }
                foreach (var role in _roles.ToList())
                {
                    _roles.Remove(role);
                }
                _unitOfWork.SaveChanges();
                return;
            }
            if (!generatorRoles.Select(d => d.Name.ToLower()).Distinct().SequenceEqual(lastRoles.Select(d => d.Name.ToLower()).Distinct()))
            {
                foreach (var groupRole in _groupRoles.ToList())
                {
                    _groupRoles.Remove(groupRole);
                }
                foreach (var role in _roles.ToList())
                {
                    _roles.Remove(role);
                }
                foreach (var role in generatorRoles)
                {
                    _roles.Add(new Role
                    {
                        NameFa = role.NameFa,
                        Name = role.Name,
                        Description = role.Description,
                        RoleType = (RoleType)role.Type,
                        RoleCategory = (RoleCategory)role.Category,
                        NormalizedName = _keyNormalizer.Normalize(role.Name)
                    });
                }

                _unitOfWork.SaveChanges();
            }
        }

        public void AddReferenceRoles()
        {
            List<SystemRoleItem> generatorRoles = new List<SystemRoleItem>();
            var generalRoles = SystemRoles.GetAll;

            foreach (var role in generalRoles)
            {
                generatorRoles.Add(role);
            }
            foreach (var role in generatorRoles)
            {
                if (!string.IsNullOrWhiteSpace(role.ReferenceRoleName))
                {
                    var childRole = _roles.FirstOrDefault(d => d.Name == role.Name);
                    var parentRole = _roles.FirstOrDefault(d => d.Name == role.ReferenceRoleName);
                    childRole.ReferenceRoleId = parentRole.Id;
                }
            }
            _unitOfWork.SaveChanges();
        }

        public void SeedGroups()
        {
            var groups = _groups.ToList();
            var newGeneratorGroups = SystemGroups.GetAll;
            if (newGeneratorGroups == null)
            {
                foreach (var groupRole in _groupRoles.ToList())
                {
                    _groupRoles.Remove(groupRole);
                }
                foreach (var @group in _groups.ToList())
                {
                    foreach (var user in _users.Where(d => d.GroupId == @group.Id))
                    {
                        _users.Remove(user);
                        foreach (var userRole in user.Roles)
                        {
                            _userRoles.Remove(userRole);
                        }
                    }
                    _groups.Remove(group);
                }
                _unitOfWork.SaveChanges();
                return;
            }
            var sequenceEqualGroups = newGeneratorGroups.Select(d => d.NameEn.ToLower()).Distinct().SequenceEqual(groups.Select(d => d.NameEn.ToLower()));
            if (sequenceEqualGroups)
            {
                foreach (var newGeneratorGroup in newGeneratorGroups)
                {
                    if (!newGeneratorGroup.RoleNames.Select(d => d.ToLower()).SequenceEqual(_groupRoles.Include(d => d.Role).Select(d => d.Role.Name.ToLower())))
                    {
                        sequenceEqualGroups = false;
                        break;
                    }
                }
            }
            if (!sequenceEqualGroups)
            {
                var roles = _roles.ToList();
                foreach (var groupRole in _groupRoles.ToList())
                {
                    _groupRoles.Remove(groupRole);
                }
                foreach (var @group in _groups.ToList())
                {
                    foreach (var user in _users.Where(d => d.GroupId == @group.Id))
                    {
                        _users.Remove(user);
                        foreach (var userRole in user.Roles)
                        {
                            _userRoles.Remove(userRole);
                        }
                    }
                    _groups.Remove(group);
                }
                foreach (var newGeneratorGroup in newGeneratorGroups)
                {
                    var groupRoles = roles.Where(d => newGeneratorGroup.RoleNames.Select(f => f.ToLower()).ToList().Contains(d.Name.ToLower())).ToList();
                    var @group = new Group
                    {
                        NameFa = newGeneratorGroup.NameFa,
                        NameEn = newGeneratorGroup.NameEn,
                        Description = newGeneratorGroup.Description,
                        GroupStatus = GroupStatus.Active,
                        GroupType = GroupType.System,
                        GroupCategory = (GroupCategory)newGeneratorGroup.Category
                    };
                    foreach (var groupRole in groupRoles)
                    {
                        @group.GroupRoles.Add(new GroupRole
                        {
                            GroupId = @group.Id,
                            RoleId = groupRole.Id
                        });
                    }
                    _groups.Add(@group);
                }
                _unitOfWork.SaveChanges();
            }
        }

        public void SeedUsers()
        {
            var valueGeneratorUsers = SystemUsers.GetAll;
            if (valueGeneratorUsers == null)
            {
                return;
            }

            foreach (var valueGeneratorUser in valueGeneratorUsers)
            {
                var user = _users.Include(d => d.Roles).ThenInclude(d => d.Role)
                    .FirstOrDefault(d => d.UserName == valueGeneratorUser.Username);
                if (user == null)
                {
                    var newUser = new User
                    {
                        Email = valueGeneratorUser.Email,
                        UserName = valueGeneratorUser.Username,
                        NormalizedEmail = _keyNormalizer.Normalize(valueGeneratorUser.Email),
                        NormalizedUserName = _keyNormalizer.Normalize(valueGeneratorUser.Username),
                        PhoneNumber = valueGeneratorUser.Username,
                        PasswordHash = _securityService.GetSha256Hash(valueGeneratorUser.Password),
                        UserStatus = UserStatus.Active,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        FirstName = valueGeneratorUser.FirstName,
                        LastName = valueGeneratorUser.LastName,
                    };
                    var group = _groups.First(d => d.NameEn.ToLower() == valueGeneratorUser.GroupNameEn.ToLower());
                    newUser.GroupId = group.Id;
                    foreach (var groupGroupRole in @group.GroupRoles)
                    {
                        newUser.Roles.Add(new UserRole
                        {
                            RoleId = groupGroupRole.RoleId,
                            UserId = newUser.Id
                        });
                    }
                    _users.Add(newUser);
                }
                else
                {
                    var group = _groups.Include(d => d.GroupRoles).First(d => d.NameEn.ToLower() == valueGeneratorUser.GroupNameEn.ToLower());
                    if (!user.Roles.Select(d => d.RoleId).SequenceEqual(group.GroupRoles.Select(d => d.RoleId)))
                    {
                        user.GroupId = group.Id;
                        foreach (var userRole in user.Roles)
                        {
                            _userRoles.Remove(userRole);
                        }
                        user.Roles.Clear();
                        foreach (var groupGroupRole in @group.GroupRoles)
                        {
                            user.Roles.Add(new UserRole
                            {
                                RoleId = groupGroupRole.RoleId,
                                UserId = user.Id
                            });
                        }
                    }
                }
            }
            _unitOfWork.SaveChanges();
        }
    }
}
