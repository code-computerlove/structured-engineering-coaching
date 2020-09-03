using System;
using System.Linq;

namespace WidgetCo
{
	public class Orders
	{
		private readonly ICustomers _customers;
		private readonly IOrderLineFactory _orderLineFactory;
		private readonly IFulfilment _fulfilment;

		public Orders(
			ICustomers customers,
			IOrderLineFactory orderLineFactory,
			IFulfilment fulfilment)
		{
			_customers = customers;
			_orderLineFactory = orderLineFactory;
			_fulfilment = fulfilment;
		}

		public void Process(OrderForm orderForm)
		{
			OrderValidator.Validate(orderForm);

			var customer = _customers.Get(orderForm.CustomerDetails.Email);

			var orderLines =
				orderForm
					.OrderLines
					.Select(orderLine => _orderLineFactory.Validate(orderLine)).ToArray();

			if (orderLines.Any(x => x == null))
			{
				throw new Exception("Something went wrong");
			}

			var order = new Order {Customer = customer, OrderLines = orderLines};

			_fulfilment.Process(order);
		}
	}
}
