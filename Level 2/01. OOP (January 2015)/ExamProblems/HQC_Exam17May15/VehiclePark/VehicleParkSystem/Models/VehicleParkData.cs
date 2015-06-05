namespace VehicleParkSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using Wintellect.PowerCollections;

    public class VehicleParkData
    {
        public VehicleParkData(int numberOfSectors)
        {
            this.VehiclesInParkPlaces = new Dictionary<IVehicle, string>();
            this.ParkPlaces = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlate = new Dictionary<string, IVehicle>();
            this.VehicleByStartTime = new Dictionary<IVehicle, DateTime>();
            this.VehiclesByOwner = new MultiDictionary<string, IVehicle>(false);
            this.SpacesCount = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> VehiclesInParkPlaces { get; set; }

        public Dictionary<string, IVehicle> ParkPlaces { get; set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> VehicleByStartTime { get; set; }

        public MultiDictionary<string, IVehicle> VehiclesByOwner { get; set; }

        public int[] SpacesCount { get; set; }
    }
}