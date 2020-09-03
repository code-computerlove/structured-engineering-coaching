using WidgetCo.Exceptions;

namespace WidgetCo
{
	public static class OrderValidator
	{
		public static void Validate(OrderForm of)
		{
			if (string.IsNullOrWhiteSpace(of.CustomerDetails.Email))
				throw new InvalidException("Customer email cannot be blank");

			for (var i = 0; i < of.OrderLines.Length; i++)
			{
				if (!of.OrderLines[i].ProductCode.StartsWith("W") && !of.OrderLines[i].ProductCode.StartsWith("G"))
				{
					throw new InvalidException("Product must be either a widget or gizmo");
				}

				if (of.OrderLines[i].ProductCode.StartsWith("W") && of.OrderLines[i].ProductCode.Substring(1).Length != 4)
				{
					throw new InvalidException("Widget codes must contain 4 digits");
				}

				if (of.OrderLines[i].ProductCode.StartsWith("W") && of.OrderLines[i].Quantity % 1 != 0)
				{
					throw new InvalidException("Widget are sold by the unit so quantity must be whole number");
				}

				if (of.OrderLines[i].ProductCode.StartsWith("G") && of.OrderLines[i].ProductCode.Substring(1).Length != 3)
				{
					throw new InvalidException("Gizmo codes must contain 3 digits");
				}
			}
		}
	}
}
