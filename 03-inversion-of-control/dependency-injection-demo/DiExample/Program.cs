using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DiExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Configure IoC framework
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            await using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Resolve instance from IoC framework
            var instance = serviceProvider.GetService<App>();

            // GO!
            instance.Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<App>()
                .AddSingleton<IDateTimeOffset, DateTimeOffsetWrapper>()
                .AddTransient<FortuneCookie>()
                .AddTransient<PersonFactory>();
        }
    }
}
