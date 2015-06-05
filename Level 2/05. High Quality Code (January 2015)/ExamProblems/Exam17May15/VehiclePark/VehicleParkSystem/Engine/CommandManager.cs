namespace VehicleParkSystem.Engine
{
    using System;
    using System.Globalization;
    using Interfaces;
    using Models;
    using Models.Vehicle;

    public class CommandManager
    {
        private VehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && this.VehiclePark == null)
            {
                throw new InvalidOperationException(Messages.ParkNotSetUp);
            }

            switch (command.Name)
            {
                case "SetupPark":
                    this.VehiclePark = new VehiclePark(int.Parse(command.CommandParameters["sectors"]), int.Parse(command.CommandParameters["placesPerSector"]));
                    return Messages.CreatedPark;
                case "Park":
                    return this.ParkVehicle(command, command.CommandParameters["type"]);
                case "Exit":
                    return this.VehiclePark.ExitVehicle(
                        command.CommandParameters["licensePlate"],
                        DateTime.Parse(command.CommandParameters["time"], null, DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.CommandParameters["paid"]));
                case "Status":
                    return this.VehiclePark.GetStatus();
                case "FindVehicle":
                    return this.VehiclePark.FindVehicle(command.CommandParameters["licensePlate"]);
                case "VehiclesByOwner":
                    return this.VehiclePark.FindVehiclesByOwner(command.CommandParameters["owner"]);
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }
        }

        private string ParkVehicle(ICommand command, string vehicleType)
        {
            switch (vehicleType.ToLower())
            {
                case "car":
                    return this.VehiclePark.InsertCar(
                        new Car(
                            command.CommandParameters["licensePlate"],
                            command.CommandParameters["owner"],
                            int.Parse(command.CommandParameters["hours"])),
                            int.Parse(command.CommandParameters["sector"]),
                            int.Parse(command.CommandParameters["place"]),
                            DateTime.Parse(command.CommandParameters["time"], null, DateTimeStyles.RoundtripKind));
                case "motorbike":
                    return this.VehiclePark.InsertMotorbike(
                        new Motorbike(
                            command.CommandParameters["licensePlate"],
                            command.CommandParameters["owner"],
                            int.Parse(command.CommandParameters["hours"])), 
                            int.Parse(command.CommandParameters["sector"]),
                            int.Parse(command.CommandParameters["place"]),
                            DateTime.Parse(command.CommandParameters["time"], null, DateTimeStyles.RoundtripKind));
                case "truck":
                    return this.VehiclePark.InsertTruck(
                        new Truck(
                            command.CommandParameters["licensePlate"],
                            command.CommandParameters["owner"],
                            int.Parse(command.CommandParameters["hours"])),
                            int.Parse(command.CommandParameters["sector"]),
                            int.Parse(command.CommandParameters["place"]),
                            DateTime.Parse(command.CommandParameters["time"], null, DateTimeStyles.RoundtripKind));
                default:
                    throw new InvalidOperationException(Messages.InvalidCommand);
            }
        }
    }
}