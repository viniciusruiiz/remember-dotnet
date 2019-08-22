using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Repository
{
    public class MemoryLineRepository : IMemoryLineRepository
    {
        MemoryLine Get(Guid id)
        {
            MemoryLine entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.Get<MemoryLine>(id);
            }

            return entity;
        }

        MemoryLine Insert(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(entity);

                transaction.Commit();
            }

            return entity;
        }

        MemoryLine Update(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(entity);

                transaction.Commit();
            }

            return entity;
        }

        MemoryLine Delete(MemoryLine entity)
        {
            using (ISession session = SessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(entity);

                transaction.Commit();
            }

            return entity;
        }

        List<MemoryLine> GetByUser(Guid userId)
        {
            List<MemoryLine> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                //TODO: Validate
                entity = session.QuerOver<MemoryLine>()
                    .JoinQueryOver<User>(x => x.Host)
                    .Where(x => x.Id == userId)
                    .JoinQueryOver<User>(x => x.Guest)
                    .Where(x => x.Id == userId)
                    .OrderBy(x => x.CreatedAt)
                    .Desc()
                    .ToList();
            }

            return entity;
        }
    }
}
