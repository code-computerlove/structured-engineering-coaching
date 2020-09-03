namespace WidgetCo.Ui
{
	// This is a stand in for some sort
	// of UI such as a website
	public class OrderApi
	{
		private readonly Orders _orders;

		public OrderApi(Orders orders)
		{
			_orders = orders;
		}

		public void MakeOrder(OrderForm orderForm)
		{
			_orders.Process(orderForm);
		}
	}
}
