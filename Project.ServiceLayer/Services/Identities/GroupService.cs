using Microsoft.EntityFrameworkCore;
using Project.Common.Extensions;
using Project.DataLayer.Context;
using Project.DomainClasses.Entities.Identities;
using Project.ServiceLayer.Contracts.Identities;

namespace Project.ServiceLayer.Services.Identities
{
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<Group> _groups;

        public GroupService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _unitOfWork.CheckArgumentIsNull(nameof(_unitOfWork));

            _groups = _unitOfWork.Set<Group>();
        }
    }
}
