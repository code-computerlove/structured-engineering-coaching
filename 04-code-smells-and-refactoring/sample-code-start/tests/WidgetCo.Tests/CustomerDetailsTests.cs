using FakeItEasy;
using WidgetCo.Exceptions;
using Xunit;

namespace WidgetCo.Tests
{
	public class WhenCustomerEmailIsBlank
	{
		[Fact]
		public void ItShouldThrowAnInvalidException()
		{
			var customerDetails = new CustomerDetails {Email = ""};
			var orderForm = new OrderForm {CustomerDetails = customerDetails};

			var sut = new Orders(A.Dummy<ICustomers>(), A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<InvalidException>(() => sut.Process(orderForm));
		}
	}

	public class WhenCustomerIsUnrecognised
	{
		[Fact]
		public void ItShouldThrowANotFoundException()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var orderForm = new OrderForm {CustomerDetails = customerDetails};

			var customers = A.Fake<ICustomers>();
			A.CallTo(() => customers.Get(customerDetails.Email))
				.Throws(new NotFoundException("Customer not recognised."));

			var sut = new Orders(customers, A.Dummy<IOrderLineFactory>(), A.Dummy<IFulfilment>());

			Assert.Throws<NotFoundException>(() => sut.Process(orderForm));
		}
	}

	public class WhenCustomerIsRecognised
	{
		[Fact]
		public void ItShouldBeIncludedOnTheOrderSentToFulfilment()
		{
			var customerDetails = new CustomerDetails {Email = "john@doe.com"};
			var customer = new Customer {EmailAddress = customerDetails.Email};

			var customers = A.Fake<ICustomers>();
			A.CallTo(() => customers.Get(customerDetails.Email)).Returns(customer);

			var fulfilment = A.Fake<IFulfilment>();
			Order capturedOrder = null;
			A.CallTo(() => fulfilment.Process(A<Order>._)).Invokes((Order o) => capturedOrder = o);

			var orderForm = new OrderForm {CustomerDetails = customerDetails};

			var sut = new Orders(customers, A.Dummy<IOrderLineFactory>(), fulfilment);

			sut.Process(orderForm);

			Assert.Equal(customer, capturedOrder.Customer);
		}
	}
}
