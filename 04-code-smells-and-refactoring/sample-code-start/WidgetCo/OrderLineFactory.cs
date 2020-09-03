using System;

namespace WidgetCo
{
	public class OrderLineFactory : IOrderLineFactory
	{
		private readonly IProductCatalogue _productCatalogue;

		public OrderLineFactory(IProductCatalogue productCatalogue)
		{
			_productCatalogue = productCatalogue;
		}

		public OrderLine Validate(UnvalidatedOrderLine unValOrd)
		{
			OrderLine orderLine = null;

			var product = _productCatalogue.Get(unValOrd.ProductCode);

			if (unValOrd.ProductCode.StartsWith("W"))
			{
				var quantity = Convert.ToInt32(unValOrd.Quantity);
				orderLine = new WidgetOrderLine {Product = product, Quantity = quantity};
			}
			else if (unValOrd.ProductCode.StartsWith("G"))
			{
				orderLine = new GizmoOrderLine {Product = product, Quantity = unValOrd.Quantity};
			}

			return orderLine;
		}
	}
}
