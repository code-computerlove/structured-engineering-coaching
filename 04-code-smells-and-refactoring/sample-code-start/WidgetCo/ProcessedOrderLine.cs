namespace WidgetCo
{
	public class ProcessedOrderLine
	{
		public Product Product { get; set; }
	}

	public class WidgetOrderLine : ProcessedOrderLine
	{
		public int Quantity { get; set; }
	}

	public class GizmoOrderLine : ProcessedOrderLine
	{
		public decimal Quantity { get; set; }
	}
}
