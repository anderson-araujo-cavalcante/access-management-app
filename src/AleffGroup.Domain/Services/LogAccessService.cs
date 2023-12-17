using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Repositories;
using AleffGroup.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace AleffGroup.Domain.Services
{
    public class LogAccessService : ServiceBase<LogAccess>, ILogAccessService
    {
        private readonly ILogAccessRepository _logAccessRepository;
        public LogAccessService(ILogAccessRepository logAccessRepository) : base(logAccessRepository)
        {
            _logAccessRepository = logAccessRepository ?? throw new ArgumentNullException(nameof(logAccessRepository));
        }

        public IEnumerable<LogAccess> GetAllByUserId(int? userId)
        {
            return _logAccessRepository.GetAllByUserId(userId);
        }
    }
}
