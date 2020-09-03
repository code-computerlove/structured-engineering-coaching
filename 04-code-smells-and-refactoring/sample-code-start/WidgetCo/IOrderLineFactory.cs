namespace WidgetCo
{
	public interface IOrderLineFactory
	{
		OrderLine Validate(UnvalidatedOrderLine unValOrd);
	}
}
