using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;
using Project.ServiceLayer.Contracts.Messages;
using Project.ServiceLayer.Services.Helper;
using Project.ServiceLayer.Services.Identities;
using Project.ServiceLayer.Services.Messages;

namespace Project.IocConfig
{
    public static class AddProjectServicesExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, ApplicationDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IPrincipal>(provider =>
                provider.GetService<IHttpContextAccessor>()?.HttpContext?.User ?? ClaimsPrincipal.Current);

            services.AddScoped<ILookupNormalizer, CustomNormalizer>();
            services.AddScoped<UpperInvariantLookupNormalizer, CustomNormalizer>();

            services.AddScoped<ISecurityStampValidator, CustomSecurityStampValidator>();
            services.AddScoped<SecurityStampValidator<User>, CustomSecurityStampValidator>();

            services.AddScoped<IPasswordValidator<User>, CustomPasswordValidator>();
            services.AddScoped<PasswordValidator<User>, CustomPasswordValidator>();

            services.AddScoped<IUserValidator<User>, CustomUserValidator>();
            services.AddScoped<UserValidator<User>, CustomUserValidator>();

            services.AddScoped<IUserClaimsPrincipalFactory<User>, CustomClaimsPrincipalFactory>();
            services.AddScoped<UserClaimsPrincipalFactory<User, Role>, CustomClaimsPrincipalFactory>();

            services.AddScoped<IdentityErrorDescriber, CustomIdentityErrorDescriber>();

            services.AddScoped<IUserStoreService, UserStoreService>();
            services.AddScoped<UserStore<User, Role, ApplicationDbContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>, UserStoreService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<UserManager<User>, UserService>();

            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<RoleManager<Role>, RoleService>();

            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<SignInManager<User>, SignInService>();

            services.AddScoped<IRoleStoreService, RoleStoreService>();
            services.AddScoped<RoleStore<Role, ApplicationDbContext, Guid, UserRole, RoleClaim>, RoleStoreService>();

            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ISmsService, SmsService>();

            services.AddScoped<IIdentityDataInitializerService, IdentityDataInitializerService>();
            services.AddScoped<IGroupRoleService, GroupRoleService>();
            services.AddScoped<IUserChangeLogService, UserChangeLogService>();
            services.AddScoped<IUsedPasswordService, UsedPasswordService>();
            services.AddScoped<ISiteStateService, SiteStateService>();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IUserTokenFactoryService, UserTokenFactoryService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserTokenStorageService, UserTokenStorageService>();
            services.AddScoped<IUserTokenValidatorService, UserTokenValidatorService>();
            services.AddScoped<IAntiForgeryCookieService, AntiForgeryCookieService>();
            services.AddScoped<IGeographicalDistanceService, GeographicalDistanceService>();

            return services;
        }
    }
}
