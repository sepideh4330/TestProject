using Microsoft.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class UserChangeLogService : IUserChangeLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<UserChangeLog> _userChangeLogs;

        public UserChangeLogService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _userChangeLogs = _unitOfWork.Set<UserChangeLog>();
        }
    }
}
