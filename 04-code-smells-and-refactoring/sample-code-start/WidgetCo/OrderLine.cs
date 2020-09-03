using WidgetCo.Exceptions;

namespace WidgetCo
{
	public class OrderLine
	{
		public string ProductCode { get; set; }

		// Widgets are sold by the unit
		// Gizmos are sold by weight in kg
		public decimal Quantity { get; set; }

		internal void Validate()
		{
			if (ProductCode.StartsWith("W"))
			{
				ValidateWidget();
			}
			else if (ProductCode.StartsWith("G"))
			{
				ValidateGizmo();
			}
			else
			{
				throw new InvalidException("Product must be either a widget or gizmo");
			}
		}

		private void ValidateWidget()
		{
			var widgetCode = ProductCode.Substring(1);

			if (widgetCode.Length != 4)
			{
				throw new InvalidException("Widget codes must contain 4 digits");
			}

			if (Quantity % 1 != 0)
			{
				throw new InvalidException("Widget are sold by the unit so quantity must be whole number");
			}
		}

		private void ValidateGizmo()
		{
			var widgetCode = ProductCode.Substring(1);

			if (widgetCode.Length != 3)
			{
				throw new InvalidException("Gizmo codes must contain 3 digits");
			}
		}
	}
}
