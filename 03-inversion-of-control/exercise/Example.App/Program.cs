using System.Threading.Tasks;

namespace Example.App
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var process = new DemoProcess();
			await process.Run();
		}
	}
}
