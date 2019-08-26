using Remember.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.Domain.Interface.Repository
{
    public interface IUserRepository
    {
        User Get(Guid id);

        User GetByEmail(string email);

        User Insert(User entity);

        User Update(User entity);

        User Disable(User entity);

        User GetRandom();
    }
}
