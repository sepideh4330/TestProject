using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Project.Common.AppSettings;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Base;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class UsedPasswordService : IUsedPasswordService
    {
        private readonly int _changePasswordReminderDays;
        private readonly int _notAllowedPreviouslyUsedPasswords;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<UserUsedPassword> _userUsedPasswords;

        public UsedPasswordService(
            IUnitOfWork unitOfWork,
            IPasswordHasher<User> passwordHasher,
            IOptionsSnapshot<SiteSettings> configurationRoot)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _userUsedPasswords = _unitOfWork.Set<UserUsedPassword>();
            _userUsedPasswords.CheckArgumentIsNull(nameof(_userUsedPasswords));

            _passwordHasher = passwordHasher;
            _passwordHasher.CheckArgumentIsNull(nameof(_passwordHasher));

            configurationRoot.CheckArgumentIsNull(nameof(configurationRoot));
            var configurationRootValue = configurationRoot.Value;
            configurationRootValue.CheckArgumentIsNull(nameof(configurationRootValue));

            _notAllowedPreviouslyUsedPasswords = configurationRootValue.NotAllowedPreviouslyUsedPasswords;
            _changePasswordReminderDays = configurationRootValue.ChangePasswordReminderDays;
        }

        public async Task AddToUsedPasswordsListAsync(User user)
        {
            await _userUsedPasswords.AddAsync(new UserUsedPassword
            {
                UserId = user.Id,
                HashedPassword = user.PasswordHash
            }).ConfigureAwait(false);
            await _unitOfWork.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<DateTimeOffset?> GetLastUserPasswordChangeDateAsync(Guid userId)
        {
            var lastPasswordHistory =
                await _userUsedPasswords//.AsNoTracking() --> removes shadow properties
                                        .OrderByDescending(userUsedPassword => userUsedPassword.Id)
                                        .FirstOrDefaultAsync(userUsedPassword => userUsedPassword.UserId == userId)
                                        .ConfigureAwait(false);

            if (lastPasswordHistory == null)
            {
                return null;
            }

            var createdDateValue = _unitOfWork.GetShadowPropertyValue(lastPasswordHistory, AuditableShadowProperties.CreatedDateTimeOn);
            return (DateTimeOffset?)createdDateValue;
        }

        public async Task<bool> IsLastUserPasswordTooOldAsync(Guid userId)
        {
            var createdDateTime = await GetLastUserPasswordChangeDateAsync(userId).ConfigureAwait(false);
            if (createdDateTime == null)
            {
                return false;
            }
            return createdDateTime.Value.AddDays(_changePasswordReminderDays) < DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// This method will be used by CustomPasswordValidator automatically,
        /// every time a user wants to change his/her info.
        /// </summary>
        public Task<bool> IsPreviouslyUsedPasswordAsync(User user, string newPassword)
        {
            var userId = user.Id;
            return
                _userUsedPasswords
                    .AsNoTracking()
                    .Where(userUsedPassword => userUsedPassword.UserId == userId)
                    .OrderByDescending(userUsedPassword => userUsedPassword.Id)
                    .Select(userUsedPassword => userUsedPassword.HashedPassword)
                    .Take(_notAllowedPreviouslyUsedPasswords)
                    .AnyAsync(hashedPassword => _passwordHasher.VerifyHashedPassword(user, hashedPassword, newPassword) != PasswordVerificationResult.Failed);
        }
    }

}
