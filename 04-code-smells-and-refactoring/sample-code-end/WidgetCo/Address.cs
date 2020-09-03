namespace WidgetCo
{
	public class Name
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }

		public string FullName()
		{
			return FirstName + " " + LastName;
		}
	}

	public class Address
	{
		public Name Name { get; } = new Name();
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string Postcode { get; set; }

		public Address(string addressLine1, string addressLine2, string postcode)
		{
			AddressLine1 = addressLine1;
			AddressLine2 = addressLine2;
			Postcode = postcode;
		}
	}
}
