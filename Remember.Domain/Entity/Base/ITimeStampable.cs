using System;

namespace Remember.Domain.Entity
{
    public interface ITimeStampable
    {
        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
