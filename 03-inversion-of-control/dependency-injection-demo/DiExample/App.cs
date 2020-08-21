using System;

namespace DiExample
{
	public class App
	{
		private readonly FortuneCookie _fortuneCookie;
		private readonly PersonFactory _personFactory;

		public App(FortuneCookie fortuneCookie, PersonFactory personFactory)
		{
			_fortuneCookie = fortuneCookie;
			_personFactory = personFactory;
		}

		public void Run()
		{
			var person = _personFactory.Create("Bob", "Bobson", "bob@bob.com", "1234",
				new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero));

			Console.WriteLine(
				"Hi {0}! You're fortune for today is: {1}\nOn your birthday it was: {2}\nYou are one lucky person!",
				person.FirstName,
				_fortuneCookie.GetTodaysFortune(),
				_fortuneCookie.GetFortuneForDate(person.Birthday));
		}
	}
}
