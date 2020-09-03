namespace WidgetCo
{
	public class OrderForm
	{
		public CustomerDetails CustomerDetails { get; set; }
		public OrderLine[] OrderLines { get; set; }

		public OrderForm()
		{
			OrderLines = new OrderLine[0];
		}

		public void Validate()
		{
			CustomerDetails.Validate();

			foreach (var orderLine in OrderLines)
			{
				orderLine.Validate();
			}
		}
	}
}
