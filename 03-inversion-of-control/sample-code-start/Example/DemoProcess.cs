using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
	public class DemoProcess
	{
		public async Task Run()
		{
			var data = File.ReadAllText("data.json");

			var client = new HttpClient {BaseAddress = new Uri("https://demoexercise.free.beeceptor.com")};

			var message = new HttpRequestMessage(
				HttpMethod.Post,
				$"/endpoint?date={DateTimeOffset.UtcNow:O}")
			{
				Content = new StringContent(data, Encoding.UTF8, "text/plain")
			};

			var response = await client.SendAsync(message);
			response.EnsureSuccessStatusCode();
		}
	}
}
