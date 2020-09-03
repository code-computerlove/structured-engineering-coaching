namespace WidgetCo
{
	public class Order
	{
		public Customer Customer { get; set; }
		public OrderLine[] OrderLines { get; set; }
	}
}
