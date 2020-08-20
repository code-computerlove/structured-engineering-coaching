using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using HttpDemo.Ui;
using Xunit;

namespace HttpDemo.Tests
{
	public class FooApiTests
	{
		[Fact]
		public async Task DemonstratingFakingHttp()
		{
			// Faking out HTTP
			var expectedFoo = new FooResource {Id = 1, Value = "Hello, World!"};

			string responseJson = JsonSerializer.Serialize(expectedFoo);

			var messageHandler = new MockHttpMessageHandler(responseJson, HttpStatusCode.OK);

			using var httpClient = new HttpClient(messageHandler) {BaseAddress = new Uri("https://needs.an.address")};
			// End of faking out HTTP

			// Arrange
			var fooApi = new FooApi(httpClient);

			// Act
			FooResource actual = await fooApi.GetFoo(1);

			// Assert
			Assert.Equal("Hello, World!", actual.Value);
		}
	}
}
