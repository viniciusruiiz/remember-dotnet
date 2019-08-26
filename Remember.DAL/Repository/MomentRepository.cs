using DAL.Utils;
using NHibernate;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Repository
{
    public class MomentRepository : IMomentRepository
    {
        public Moment Get(Guid id)
        {
            Moment entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.Get<Moment>(id);
            }

            return entity;
        }

        public Moment Insert(Moment entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);

                transaction.Commit();
            }

            return entity;
        }

        public Moment Update(Moment entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);

                transaction.Commit();
            }

            return entity;
        }

        public Moment Delete(Moment entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);

                transaction.Commit();
            }

            return entity;
        }

        public List<Moment> GetByMemoryLine(Guid id)
        {
            IList<Moment> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver<Moment>()
                    .JoinQueryOver(x => x.MemoryLine)
                    .Where(x => x.Id == id)
                    .OrderBy(x => x.CreatedAt)
                    .Desc
                    .List();
            }

            return entity as List<Moment>;
        }
    }
}
