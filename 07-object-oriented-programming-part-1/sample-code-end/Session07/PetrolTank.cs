namespace Session07
{
	public class PetrolTank
	{
		private float MaxFuelInGallons;
		private float CurrentFuelInGallons;

		public PetrolTank(float maxFuelInGallons, float currentFuelInGallons)
		{
			MaxFuelInGallons = maxFuelInGallons;
			CurrentFuelInGallons = currentFuelInGallons;
		}

		public string Status()
		{
			var currentLevel = CurrentFuelInGallons / MaxFuelInGallons * 100.0;

			return $"The petrol tank is {currentLevel}% full";
		}
	}

	public class Dashboard
	{
		private readonly PetrolTank _petrolTank;

		public Dashboard(PetrolTank petrolTank)
		{
			_petrolTank = petrolTank;
		}
	}
}
