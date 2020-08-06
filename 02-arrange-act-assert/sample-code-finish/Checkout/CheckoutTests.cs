using System.Collections.Generic;
using Xunit;

namespace Checkout
{
    /*
     Checkout Kata

    Implement the code for a checkout system that handles pricing
    schemes such as "pineapples cost 50, three pineapples cost 130."

    Implement the code for a supermarket checkout that calculates the
    total price of a number of items. In a normal supermarket, things
    are identified using Stock Keeping Units, or SKUs. In our store,
    we値l use individual letters of the alphabet (A, B, C, and so on).
    Our goods are priced individually. In addition, some items are multi-priced:
    buy n of them, and they値l cost you y pence. For example, item A might cost
    50 individually, but this week we have a special offer: buy three As and
    they値l cost you 130. In fact the prices are:


    SKU   Unit   Price Special Price
    A     45     3 for 130
    B     30     2 for 45
    C     20
    D     15

    The checkout accepts items in any order, so that if we scan a B, an A,
    and another B, we値l recognize the two Bs and price them at 45
    (for a total price so far of 95). The pricing changes frequently, so
    pricing should be independent of the checkout.

    interface ICheckout
    {
    void Scan(string sku);
    int GetTotalPrice();
    }
     */

    public class CheckoutTests
    {
        [Fact]
        public void WhenItemsAreScannedTheTotalShouldBeTheCombinedCostOfTheItems()
        {
            var checkout = new Checkout(new Prices(new Dictionary<string, int>
            {
                {"A", 45},
                {"B", 30}
            }));

            checkout.Scan("A");
            checkout.Scan("B");

            var total = checkout.GetTotalPrice();
            Assert.Equal(75, total);
        }
    }

    public class Checkout
    {
        private int _runningTotal;
        private readonly Prices _prices;

        public Checkout(Prices prices)
        {
            _prices = prices;
        }

        public void Scan(string sku)
        {
            _runningTotal += _prices.PriceFor(sku);
        }

        public int GetTotalPrice()
        {
            return _runningTotal;
        }
    }
}
