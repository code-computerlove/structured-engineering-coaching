using WidgetCo.Exceptions;

namespace WidgetCo
{
	public class UnvalidatedOrderLine
	{
		// W1234
		// G123
		public string ProductCode { get; set; }

		// Widgets are sold by the unit
		// Gizmos are sold by weight in kg
		public decimal Quantity { get; set; }

		public void Validate()
		{
			if (!IsWidget && !IsGizmo)
			{
				throw new InvalidException("Product must be either a widget or gizmo");
			}

			if (IsWidget)
			{
				ValidateWidget();
			}

			if (IsGizmo)
			{
				ValidateGizmo();
			}
		}

		private void ValidateWidget()
		{
			if (ProductCode.Substring(1).Length != 4)
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
			if (ProductCode.Substring(1).Length != 3)
			{
				throw new InvalidException("Gizmo codes must contain 3 digits");
			}
		}

		private bool IsGizmo => ProductCode.StartsWith("G");

		private bool IsWidget => ProductCode.StartsWith("W");
	}
}
