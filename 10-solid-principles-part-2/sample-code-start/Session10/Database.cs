using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace Session10
{
	public class StockCode
	{
		public string Category { get; set; }
		public string Id { get; set; }

		public override string ToString()
		{
			return $"{Category}-{Id}";
		}
	}

	public class Widget
	{
		public StockCode StockCode { get; set; }
		public string Description { get; set; }
	}

	public class WidgetEntity : TableEntity
	{
		public string Description { get; set; }
	}

	public class WidgetAzureTable
	{
		private readonly CloudTable _cloudTable;

		public WidgetAzureTable(CloudStorageAccount cloudStorageAccount)
		{
			_cloudTable = cloudStorageAccount
				.CreateCloudTableClient(new TableClientConfiguration())
				.GetTableReference("widget");
		}

		public async Task<Widget> Get(StockCode stockCode)
		{
			var operation = TableOperation.Retrieve<WidgetEntity>(stockCode.Category, stockCode.Id);
			TableResult result = await _cloudTable.ExecuteAsync(operation);
			var entity = result.Result as WidgetEntity;

			return new Widget
			{
				StockCode = new StockCode {Category = entity.PartitionKey, Id = entity.RowKey},
				Description = entity.Description
			};
		}

		public async Task Put(Widget widget)
		{
			var entity = new WidgetEntity
			{
				PartitionKey = widget.StockCode.Category,
				RowKey = widget.StockCode.Id,
				Description = widget.Description
			};
			var operation = TableOperation.InsertOrReplace(entity);
			await _cloudTable.ExecuteAsync(operation);
		}
	}
}
