using System;

namespace DiExample
{
	public class Person
    {
	    private readonly IDateTimeOffset _dateTimeOffset;

	    public Person(IDateTimeOffset dateTimeOffset)
	    {
		    _dateTimeOffset = dateTimeOffset;
	    }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTimeOffset Birthday { get; set; }

        public bool IsBirthday()
        {
	        var today = _dateTimeOffset.UtcNow;
	        return Birthday.Day == today.Day && Birthday.Month == today.Month;
        }
    }
}
