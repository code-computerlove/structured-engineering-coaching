using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpDemo.Ui
{
	public interface IFooApi
	{
		Task<FooResource> GetFoo(int id);
	}

	public class FooApi : IFooApi
	{
		private readonly HttpClient _httpClient;

		public FooApi(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<FooResource> GetFoo(int id)
		{
			string url = "/api/v1/foo/" + id;

			using var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);

			var responseMessage = await _httpClient.SendAsync(httpRequest);

			var responseContent = await responseMessage.Content.ReadAsStringAsync();

			return JsonSerializer.Deserialize<FooResource>(responseContent);
		}
	}
}
