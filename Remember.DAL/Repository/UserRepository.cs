using DAL.Utils;
using NHibernate;
using Remember.DAL.Utils;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Remember.DAL.Repository
{
    public class UserRepository : IUserRepository
    {
        public User Disable(User entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                entity.Disable();

                session.Update(entity);

                transaction.Commit();
            }

            return entity;
        }

        public User Get(Guid id)
        {
            User entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.Get<User>(id);
            }

            return entity;
        }

        public User GetByEmail(string email)
        {
            User entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver<User>()
                    .Where(x => x.Email == email)
                    .SingleOrDefault();
            }

            return entity;
        }

        public User GetRandom()
        {
            IList<User> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver<User>()
                    .OrderByRandom()
                    .List();
            }

            return entity.FirstOrDefault();
        }

        public User Insert(User entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);

                transaction.Commit();
            }

            return entity;
        }

        public User Update(User entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);

                transaction.Commit();
            }

            return entity;
        }
    }
}
