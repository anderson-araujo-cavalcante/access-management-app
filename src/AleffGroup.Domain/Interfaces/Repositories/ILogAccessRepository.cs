using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Model;
using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Repositories
{
    public interface ILogAccessRepository : IRepositoryBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
        IEnumerable<LogTime> GetPeriodByUserId(int? userId);
    }
}
