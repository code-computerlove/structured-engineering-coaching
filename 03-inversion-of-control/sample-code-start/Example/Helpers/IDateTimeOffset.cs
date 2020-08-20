using System;

namespace Example.Helpers
{
	public interface IDateTimeOffset
	{
		DateTimeOffset UtcNow { get; }
	}
}
