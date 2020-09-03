namespace WidgetCo
{
	public abstract class Product
	{
		public string Code { get; set; }
	}

	public class Widget : Product
	{
		public int Quantity { get; set; }
	}

	public class Gizmo : Product
	{
		public decimal Quantity { get; set; }
	}
}
