using System;

namespace Example.Helpers
{
	public class DateTimeOffsetWrapper : IDateTimeOffset
	{
		public DateTimeOffset UtcNow
		{
			get
			{
				return DateTimeOffset.UtcNow;
			}
		}
	}
}
