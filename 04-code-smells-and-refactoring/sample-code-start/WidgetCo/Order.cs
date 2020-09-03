namespace WidgetCo
{
	public class Order
	{
		public Customer Customer { get; set; }
		public ProcessedOrderLine[] OrderLines { get; set; }
	}
}
