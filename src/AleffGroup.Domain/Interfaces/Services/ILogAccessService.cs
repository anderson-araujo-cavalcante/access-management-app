﻿using AleffGroup.Domain.Entities;
using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Services
{
    public interface ILogAccessService : IServiceBase<LogAccess>
    {
        IEnumerable<LogAccess> GetAllByUserId(int? userId);
    }
}
