using Remember.Domain.Entity;
using System;
using System.Collections.Generic;

namespace Remember.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        User Get(Guid id);

        Guid GetUserPkByEmail(string email);

        User Insert(User entity);

        User Update(User entity);

        User GetRandomUser();

        User GetUserByEmail(string email);

        IList<User> GetByMemoryLine(Guid memoryLineId);
    }
}
