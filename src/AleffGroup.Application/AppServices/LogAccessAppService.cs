using AleffGroup.Application.Interfaces;
using AleffGroup.Domain.Entities;
using AleffGroup.Domain.Interfaces.Services;
using AleffGroup.Domain.Services;
using System;
using System.Collections.Generic;

namespace AleffGroup.Application.AppServices
{
    public class LogAccessAppService : AppServiceBase<LogAccess>, ILogAccessAppService
    {
        private readonly ILogAccessService _logAccessService;
        public LogAccessAppService(ILogAccessService logAccessService) : base(logAccessService)
        {
            _logAccessService = logAccessService ?? throw new ArgumentNullException(nameof(logAccessService));
        }

        public IEnumerable<LogAccess> GetAllByUserId(int? userId)
        {
            return _logAccessService.GetAllByUserId(userId);
        }
    }
}
