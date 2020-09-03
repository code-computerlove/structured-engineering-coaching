using WidgetCo.Exceptions;

namespace WidgetCo
{
	public class CustomerDetails
	{
		public string Email { get; set; }

		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(Email))
				throw new InvalidException("Customer email cannot be blank");
		}
	}
}
