using FakeItEasy;
using WidgetCo.Exceptions;
using Xunit;

namespace WidgetCo.Tests
{
	public class WhenWidgetCodeContainsLessThanFourDigits
	{
		[Fact]
		public void ItShouldThrowAnInvalidException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W123", Quantity = 1};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var sut = new Orders(A.Dummy<ICustomers>(), A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<InvalidException>(() => sut.Process(orderForm));
		}
	}

	public class WhenWidgetCodeContainsMoreThanFourDigits
	{
		[Fact]
		public void ItShouldThrowAnInvalidException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W12345", Quantity = 1};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var sut = new Orders(A.Dummy<ICustomers>(), A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<InvalidException>(() => sut.Process(orderForm));
		}
	}

	public class WhenWidgetQuantityIsNotWholeNumber
	{
		[Fact]
		public void ItShouldThrowAnInvalidException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W1234", Quantity = 1.5m};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var sut = new Orders(A.Dummy<ICustomers>(), A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<InvalidException>(() => sut.Process(orderForm));
		}
	}

	public class WhenWidgetNotInCatalogue
	{
		[Fact]
		public void ItShouldThrowNotFoundException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W1234", Quantity = 1};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var productCatalogue = A.Fake<IProductCatalogue>();
			A.CallTo(() => productCatalogue.Get(orderLine.ProductCode))
				.Throws(new NotFoundException("Widget not found: " + orderLine.ProductCode));

			var processedOrderLineFactory = new OrderLineFactory(productCatalogue);

			var sut = new Orders(A.Dummy<ICustomers>(), processedOrderLineFactory, A.Dummy<IFulfilment>());

			Assert.Throws<NotFoundException>(() => sut.Process(orderForm));
		}
	}

	public class WhenWidgetIsRecognised
	{
		[Fact]
		public void ItShouldBeIncludedOnTheOrderSentToFulfilment()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W1234", Quantity = 1};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var widget = new Widget {Code = orderLine.ProductCode};
			var productCatalogue = A.Fake<IProductCatalogue>();
			A.CallTo(() => productCatalogue.Get(orderLine.ProductCode)).Returns(widget);

			var processedOrderLineFactory = new OrderLineFactory(productCatalogue);

			var fulfilment = A.Fake<IFulfilment>();
			Order capturedOrder = null;
			A.CallTo(() => fulfilment.Process(A<Order>._)).Invokes((Order o) => capturedOrder = o);

			var sut = new Orders(A.Dummy<ICustomers>(), processedOrderLineFactory, fulfilment);

			sut.Process(orderForm);

			Assert.Equal(widget, capturedOrder.OrderLines[0].Product);
		}

		[Fact]
		public void ItShouldIncludeQuantityOnTheOrderSentToFulfilment()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderLine = new UnvalidatedOrderLine {ProductCode = "W1234", Quantity = 10};
			var orderForm = new OrderForm {CustomerDetails = customerDetails, OrderLines = new[] {orderLine}};

			var widget = new Widget {Code = orderLine.ProductCode};
			var productCatalogue = A.Fake<IProductCatalogue>();
			A.CallTo(() => productCatalogue.Get(orderLine.ProductCode)).Returns(widget);

			var processedOrderLineFactory = new OrderLineFactory(productCatalogue);

			var fulfilment = A.Fake<IFulfilment>();
			Order capturedOrder = null;
			A.CallTo(() => fulfilment.Process(A<Order>._)).Invokes((Order o) => capturedOrder = o);

			var sut = new Orders(A.Dummy<ICustomers>(), processedOrderLineFactory, fulfilment);

			sut.Process(orderForm);

			var widgetOrderLine = (WidgetOrderLine)capturedOrder.OrderLines[0];

			Assert.Equal(10, widgetOrderLine.Quantity);
		}
	}
}
