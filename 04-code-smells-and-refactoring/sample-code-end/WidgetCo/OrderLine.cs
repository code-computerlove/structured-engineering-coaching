namespace WidgetCo
{
	public class OrderLine
	{
		public Product Product { get; set; }
	}

	public class WidgetOrderLine : OrderLine
	{
		public int Quantity { get; set; }
	}

	public class GizmoOrderLine : OrderLine
	{
		public decimal Quantity { get; set; }
	}
}
