using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Model;
using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Services
{
    public interface ILogAccessService : IServiceBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
        IEnumerable<LogTime> GetPeriodByUserId(int? userId);
    }
}
