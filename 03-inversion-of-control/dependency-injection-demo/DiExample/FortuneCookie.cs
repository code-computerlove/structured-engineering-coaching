using System;

namespace DiExample
{
    public class FortuneCookie
    {
        private readonly DateTimeOffset _now;

        public FortuneCookie(IDateTimeOffset dateTimeOffset)
        {
            _now = dateTimeOffset.UtcNow;
        }

        public string GetTodaysFortune()
        {
	        return GetFortuneForDate(_now);
        }

        public string GetFortuneForDate(DateTimeOffset date)
        {
	        if (date.DayOfWeek == DayOfWeek.Monday)
	        {
		        return "Bad luck falls on Mondays!";
	        }
	        else
	        {
		        return "Everything's coming up Milhouse";
	        }
        }
    }
}
