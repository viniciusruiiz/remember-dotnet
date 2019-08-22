using Remember.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Remember.Domain.Interface.Repository
{
    public interface IMemoryLineRepository
    {
        MemoryLine Get(Guid id);

        MemoryLine Insert(MemoryLine entity);

        MemoryLine Update(MemoryLine entity);

        MemoryLine Delete(MemoryLine entity);

        List<MemoryLine> GetByUser(Guid userId);
    }
}
