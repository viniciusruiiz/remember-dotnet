using Remember.Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.DAL.Repository
{
    public class MomentRepository : IMomentRepository
    {
        Moment Get(Guid id);

        Moment Insert(Moment entity);

        Moment Update(Moment entity);

        Moment Delete(Moment moment);

        List<Moment> GetByMemoryLine(Guid id)
        {
            List<Moment> entity;

            using (ISession session = SessionFactory.OpenSession())
            {
                entity = session.QuerOver<Moment>()
                    .JoinQueryOver<MemoryLine>(x => x.MemoryLine)
                    .Where(x => x.Id == id)
                    .OrderBy(x => x.CreatedAt)
                    .Desc()
                    .ToList();
            }

            return entity;
        }
    }
}
