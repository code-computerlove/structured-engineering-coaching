using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Example.Tests.Helpers;
using NUnit.Framework;

namespace Example.Tests
{
	public class MockHttpDemo
	{
		[Test]
		public async Task FakingHttpClient()
		{
			var messageHandler = new MockHttpMessageHandler("Hello, World!", HttpStatusCode.OK);

			using var httpClient = new HttpClient(messageHandler);

			var response = await httpClient.GetStringAsync("/");

			Assert.AreEqual("Hello, World!", response);
		}
	}
}
