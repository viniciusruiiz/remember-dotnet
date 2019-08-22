using Remember.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.Domain.Interface.Repository
{
    public interface IMomentRepository
    {
        Moment Get(Guid id);

        Moment Insert(Moment entity);

        Moment Update(Moment entity);

        Moment Delete(Moment moment);

        List<Moment> GetByMemoryLine(Guid id);
    }
}
