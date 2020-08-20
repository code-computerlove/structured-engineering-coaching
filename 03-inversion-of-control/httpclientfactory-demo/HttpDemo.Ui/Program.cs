using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace HttpDemo.Ui
{
	public class Program
	{
		private readonly IFooApi _fooApi;

		public Program(IFooApi fooApi)
		{
			_fooApi = fooApi;
		}

		private async Task Run()
		{
			var fooResource = await _fooApi.GetFoo(1);
		}

		static async Task Main(string[] args)
		{
			// Configure IoC framework
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);
			await using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

			// Resolve instance from IoC framework
			var instance = serviceProvider.GetService<Program>();

			// GO!
			await instance.Run();
		}

		private static void ConfigureServices(IServiceCollection serviceCollection)
		{
			serviceCollection
				.AddTransient<Program>();

			serviceCollection
				.AddHttpClient<IFooApi, FooApi>(client =>
				{
					client.BaseAddress = new Uri("http://not.real.com");
					client.DefaultRequestHeaders.Add("Accept", "application/json");
				});
		}
	}
}
