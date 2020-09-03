using FakeItEasy;
using WidgetCo.Exceptions;
using Xunit;

namespace WidgetCo.Tests
{
	public class WhenProductCodeIsForNeitherAWidgetOrGizmo
	{
		[Fact]
		public void ItShouldThrowAnInvalidException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "A1234", Quantity = 1};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var sut = new Orders(A.Dummy<ICustomers>(), A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<InvalidException>(() => sut.Process(orderForm));
		}
	}
}
