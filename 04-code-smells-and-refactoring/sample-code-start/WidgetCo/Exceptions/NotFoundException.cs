using System;

namespace WidgetCo.Exceptions
{
	public class NotFoundException : Exception
	{
		public NotFoundException(string message) : base(message) { }
	}
}
