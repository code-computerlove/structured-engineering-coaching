using System.Threading.Tasks;

namespace Example.App
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var process = new DemoProcess();
			await process.Run();
		}
	}
}
