namespace WidgetCo
{
	public interface IOrderLineFactory
	{
		OrderLine Build(UnvalidatedOrderLine unvalidatedOrderLine);
	}
}
