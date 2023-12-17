using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Model;
using System.Collections.Generic;

namespace AleffGroup.Application.Interfaces
{
    public interface ILogAccessAppService : IAppServiceBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
        IEnumerable<LogTime> GetPeriodByUserId(int? userId);
    }
}
