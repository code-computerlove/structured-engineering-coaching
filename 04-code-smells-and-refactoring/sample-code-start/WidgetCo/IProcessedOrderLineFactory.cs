namespace WidgetCo
{
	public interface IProcessedOrderLineFactory
	{
		ProcessedOrderLine BuildFrom(OrderLine orderLine);
	}
}
