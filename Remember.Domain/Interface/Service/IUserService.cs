using Remember.Domain.Arguments;
using System;

namespace Remember.Domain.Interface.Service
{
    public interface IUserService
    {
        BaseResponse Get(Guid id);

        BaseResponse GetByMemoryLine(Guid memoryLineId);
    }
}
