using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;

namespace AleffGroup.Domain.Services
{
    public class LogAccessService : ServiceBase<LogAccess>, ILogAccessService
    {
        public LogAccessService(ILogAccessRepository logAccessRepository) : base(logAccessRepository)
        {
        }
    }
}
