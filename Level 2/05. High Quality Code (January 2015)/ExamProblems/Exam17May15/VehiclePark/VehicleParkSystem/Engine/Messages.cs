namespace VehicleParkSystem.Engine
{
    public static class Messages
    {
        public const string CreatedPark = "Vehicle park created";
        public const string ParkedVehicle = "{0} parked successfully at place ({1},{2})";
        public const string SectorStatus = "Sector {0}: {1} / {2} ({3}% full)";
        public const string VehicleStatus = "{0}{1}Parked at {2}";

        public const string InvalidCommand = "Invalid command.";
        public const string ParkNotSetUp = "The vehicle park has not been set up";
        public const string NonNegative = "The {0} must be non-negative.";
        public const string Possitive = "The {0} must be positive.";
        public const string Required = "The {0} is required.";
        public const string InvalidLicensePlate = "The license plate number is invalid.";
        public const string InvalidSector = "There is no sector {0} in the park";
        public const string InvalidPlace = "There is no place {0} in sector {1}";
        public const string PlaceAlreadyOccupied = "The place ({0},{1}) is occupied";
        public const string DuplicateLicensePlate = "There is already a vehicle with license plate {0} in the park";
        public const string NonExistingLicensePlate = "There is no vehicle with license plate {0} in the park";
        public const string NonExistingVehicle = "No vehicles by {0}";
    }
}