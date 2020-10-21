namespace Session07
{
	public class PetrolTank
	{
		public float MaxFuelInGallons { get; }
		public float CurrentFuelInGallons { get; private set; }

		public PetrolTank(float maxFuelInGallons, float currentFuelInGallons)
		{
			MaxFuelInGallons = maxFuelInGallons;
			CurrentFuelInGallons = currentFuelInGallons;
		}
	}

	public class Dashboard
	{
		private readonly PetrolTank _petrolTank;

		public Dashboard(PetrolTank petrolTank)
		{
			_petrolTank = petrolTank;
		}

		public string Status()
		{
			var currentLevel = _petrolTank.CurrentFuelInGallons / _petrolTank.MaxFuelInGallons * 100.0;

			return $"The petrol tank is {currentLevel}% full";
		}
	}
}
