namespace WidgetCo
{
	public class UnvalidatedOrderLine
	{
		public string ProductCode { get; set; }

		// Widgets are sold by the unit
		// Gizmos are sold by weight in kg
		public decimal Quantity { get; set; }
	}
}
