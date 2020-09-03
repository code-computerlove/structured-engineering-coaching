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

		public OrderLine Build(UnvalidatedOrderLine unvalidatedOrderLine)
		{
			OrderLine orderLine = null;

			var product = _productCatalogue.Get(unvalidatedOrderLine.ProductCode);

			if (unvalidatedOrderLine.ProductCode.StartsWith("W"))
			{
				var quantity = Convert.ToInt32(unvalidatedOrderLine.Quantity);
				orderLine = new WidgetOrderLine {Product = product, Quantity = quantity};
			}
			else if (unvalidatedOrderLine.ProductCode.StartsWith("G"))
			{
				orderLine = new GizmoOrderLine {Product = product, Quantity = unvalidatedOrderLine.Quantity};
			}

			return orderLine;
		}
	}
}
