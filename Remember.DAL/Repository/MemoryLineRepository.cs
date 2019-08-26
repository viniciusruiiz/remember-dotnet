using DAL.Utils;
using NHibernate;
using Remember.DAL.Utils;
using Remember.Domain.Entity;
using Remember.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remember.DAL.Repository
{
    public class MemoryLineRepository : IMemoryLineRepository
    {
        public MemoryLine Get(Guid id)
        {
            MemoryLine entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.Get<MemoryLine>(id);
            }

            return entity;
        }

        public MemoryLine Insert(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);

                transaction.Commit();
            }

            return entity;
        }

        public MemoryLine Update(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);

                transaction.Commit();
            }

            return entity;
        }

        public MemoryLine Delete(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);

                transaction.Commit();
            }

            return entity;
        }

        public List<MemoryLine> GetByUser(Guid id)
        {
            IList<MemoryLine> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                MemoryLine memoryLineAlias = null;
                User hostAlias = null;
                User guestAlias = null;

                //TODO: Validate
                entity = session.QueryOver(() => memoryLineAlias)
                    .JoinAlias(() => memoryLineAlias.Host, () => hostAlias)
                    .Left.JoinAlias(() => memoryLineAlias.Guests, () => guestAlias)
                    .Where(() => hostAlias.Id == id || guestAlias.Id == id)
                    .OrderBy(x => x.CreatedAt)
                    .Desc
                    .List();
            }

            return entity as List<MemoryLine>;
        }

        public MemoryLine GetRandom()
        {
            IList<MemoryLine> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver<MemoryLine>()
                    .JoinQueryOver(x => x.Host)
                    .OrderByRandom()
                    .List();
            }

            return entity.FirstOrDefault();
        }

        public MemoryLine GetMemoryWithGuestList(Guid id)
        {
            MemoryLine entity;

            MemoryLine memoryLineAlias = null;
            User guestAlias = null;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QueryOver(() => memoryLineAlias)
                    .JoinAlias(() => memoryLineAlias.Guests, () => guestAlias)
                    .Where(() => memoryLineAlias.Id == id)
                    .SingleOrDefault();
            }

            return entity;
        }
    }
}
