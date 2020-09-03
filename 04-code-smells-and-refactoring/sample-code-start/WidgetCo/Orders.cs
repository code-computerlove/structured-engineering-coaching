using System.Linq;

namespace WidgetCo
{
	public class Orders
	{
		private readonly ICustomers _customers;
		private readonly IProcessedOrderLineFactory _processedOrderLineFactory;
		private readonly IFulfilment _fulfilment;

		public Orders(
			ICustomers customers,
			IProcessedOrderLineFactory processedOrderLineFactory,
			IFulfilment fulfilment)
		{
			_customers = customers;
			_processedOrderLineFactory = processedOrderLineFactory;
			_fulfilment = fulfilment;
		}

		public void Process(OrderForm orderForm)
		{
			orderForm.Validate();

			var customer = _customers.Get(orderForm.CustomerDetails.Email);

			var orderLines =
				orderForm
					.OrderLines
					.Select(orderLine => _processedOrderLineFactory.BuildFrom(orderLine))
					.ToArray();

			var order = new Order {Customer = customer, OrderLines = orderLines};

			_fulfilment.Process(order);
		}
	}
}
