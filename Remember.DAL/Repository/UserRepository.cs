using DAL.Utils;
using NHibernate;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

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

                Dispose(transaction);
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

        public User GetRandomUser()
        {
            User entity;

            //using (ISession session = SessionFactory.OpenSession())
            //{
            //    entity = session.Get<User>(id);
            //}

            return null;
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
    }
}
