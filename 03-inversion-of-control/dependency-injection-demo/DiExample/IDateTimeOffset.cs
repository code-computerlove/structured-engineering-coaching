using System;

namespace DiExample
{
    public interface IDateTimeOffset
    {
        DateTimeOffset UtcNow { get; }
    }
}