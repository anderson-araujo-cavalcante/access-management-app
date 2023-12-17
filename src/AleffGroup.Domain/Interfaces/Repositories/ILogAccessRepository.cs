using AleffGroup.Domain.Entities;
using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Repositories
{
    public interface ILogAccessRepository : IRepositoryBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
    }
}
