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
        public User Get(Guid id)
        {
            User entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.Get<User>(id);
            }

            return entity;
        }

        public Guid GetUserPkByEmail(string email)
        {
            Guid user;

            using (ISession session = SessionFactory.OpenSession())
            {
                user = session.QueryOver<User>()
                    .Where(x => x.Email == email)
                    .SelectList(x => x.Select(y => y.Id))
                    .SingleOrDefault<Guid>();
            }

            return user;
        }

        public User GetRandomUser()
        {
            User entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver<User>()
                    .OrderByRandom()
                    .Take(1)
                    .SingleOrDefault();
            }

            return entity;
        }

        public User Insert(User entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);

                Dispose(transaction);
            }

            return entity;
        }

        public User Update(User entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);

                Dispose(transaction);
            }

            return entity;
        }

        private void Dispose(ITransaction transaction)
        {
            transaction.Commit();
            transaction.Dispose();
        }

        public User GetUserByEmail(string email)
        {
            User user;

            using (ISession session = SessionFactory.OpenSession())
            {
                user = session.QueryOver<User>()
                    .Where(x => x.Email == email)
                    .SingleOrDefault();
            }

            return user;
        }

        public IList<User> GetByMemoryLine(Guid memoryLineId)
        {
            IList<User> users;

            using (ISession session = SessionFactory.OpenSession())
            {
                users = session.QueryOver<MemoryLine>()
                    .Where(x => x.Id == memoryLineId)
                    .Inner.JoinQueryOver(x => x.Guests)
                    .SingleOrDefault()
                    .Guests;
            }

            return users;
        }
    }
}
