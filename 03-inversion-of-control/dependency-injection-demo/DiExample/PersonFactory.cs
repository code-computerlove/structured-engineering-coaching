using System;

namespace DiExample
{
	public class PersonFactory
	{
		private readonly IDateTimeOffset _dateTimeOffset;

		public PersonFactory(IDateTimeOffset dateTimeOffset)
		{
			_dateTimeOffset = dateTimeOffset;
		}

		public Person Create(string firstName, string lastName, string email, string phoneNumber,
			DateTimeOffset birthday)
		{
			return new Person(_dateTimeOffset)
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				PhoneNumber = phoneNumber,
				Birthday = birthday
			};
		}
	}
}
