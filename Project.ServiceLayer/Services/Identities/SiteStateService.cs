using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.DomainClasses.Enums.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class SiteStateService : ISiteStateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly DbSet<User> _users;

        public SiteStateService(
            IUserService userService,
            IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _userService.CheckArgumentIsNull(nameof(_userService));

            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _users = _unitOfWork.Set<User>();
        }

        public Task<List<User>> GetOnlineUsersListAsync(int numbersToTake, int minutesToTake)
        {
            var now = DateTimeOffset.UtcNow.IranStandardTimeNow();
            var minutes = now.AddMinutes(-minutesToTake);
            return _users.AsNoTracking()
                         .Where(user => user.LastVisitDateTimeOn != null && user.LastVisitDateTimeOn.Value <= now && user.LastVisitDateTimeOn.Value >= minutes)
                         .OrderByDescending(user => user.LastVisitDateTimeOn)
                         .Take(numbersToTake)
                         .ToListAsync();
        }
    }
}
