using System;

namespace Remember.Domain.Entity.Base
{
    public interface ITimeStampable
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
