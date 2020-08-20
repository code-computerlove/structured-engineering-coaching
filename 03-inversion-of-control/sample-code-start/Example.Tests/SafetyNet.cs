using System.Threading.Tasks;
using Example.App;
using NUnit.Framework;

namespace Example.Tests
{
	public class SafetyNet
	{
		[Test]
		public async Task ExecutesSuccessfully()
		{
			await Program.Main(new string[0]);
		}
	}
}
