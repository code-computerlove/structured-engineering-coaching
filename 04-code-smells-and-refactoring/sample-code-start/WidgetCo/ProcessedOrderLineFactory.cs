using System;
using WidgetCo.Exceptions;

namespace WidgetCo
{
	public class ProcessedOrderLineFactory : IProcessedOrderLineFactory
	{
		private readonly IProductCatalogue _productCatalogue;

		public ProcessedOrderLineFactory(IProductCatalogue productCatalogue)
		{
			_productCatalogue = productCatalogue;
		}

		public ProcessedOrderLine BuildFrom(OrderLine orderLine)
		{
			ProcessedOrderLine processedOrderLine;

			if (orderLine.ProductCode.StartsWith("W"))
			{
				var product = _productCatalogue.Get(orderLine.ProductCode);
				var quantity = Convert.ToInt32(orderLine.Quantity);
				processedOrderLine = new WidgetOrderLine {Product = product, Quantity = quantity};
			}
			else if (orderLine.ProductCode.StartsWith("G"))
			{
				var product = _productCatalogue.Get(orderLine.ProductCode);
				processedOrderLine = new GizmoOrderLine {Product = product, Quantity = orderLine.Quantity};
			}
			else
			{
				throw new InvalidException("Product code must be for either a widget or gizmo");
			}

			return processedOrderLine;
		}
	}
}
