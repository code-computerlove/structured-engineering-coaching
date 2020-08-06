using System.Collections.Generic;

namespace Checkout
{
    public class Prices
    {
        private readonly Dictionary<string, int> _prices;

        public Prices(Dictionary<string, int> prices)
        {
            _prices = prices;
        }

        public int PriceFor(string sku)
        {
            return _prices[sku];
        }
    }
}