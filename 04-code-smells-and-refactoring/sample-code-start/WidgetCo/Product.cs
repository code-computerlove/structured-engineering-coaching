namespace WidgetCo
{
	public abstract class Product
	{
		public string Code { get; set; }
	}

	public class Widget : Product
	{
	}

	public class Gizmo : Product
	{
	}
}
