using AleffGroup.Domain.Entities;
using System.Collections.Generic;

namespace AleffGroup.Domain.Interfaces.Services
{
    public interface IUserService : IServiceBase<User>
    {
        IEnumerable<User> GetAll();
    }
}
