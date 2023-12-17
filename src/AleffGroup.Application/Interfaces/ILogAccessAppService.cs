using AleffGroup.Domain.Entities;
using System.Collections.Generic;

namespace AleffGroup.Application.Interfaces
{
    public interface ILogAccessAppService : IAppServiceBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
    }
}
