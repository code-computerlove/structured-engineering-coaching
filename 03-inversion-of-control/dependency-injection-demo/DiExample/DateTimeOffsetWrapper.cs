using System;

namespace DiExample
{
    public class DateTimeOffsetWrapper : IDateTimeOffset
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}