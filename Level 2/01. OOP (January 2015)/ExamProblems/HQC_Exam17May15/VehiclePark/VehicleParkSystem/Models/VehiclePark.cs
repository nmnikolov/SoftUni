namespace VehicleParkSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Engine;
    using Interfaces;
    using Vehicle;

    public class VehiclePark : IVehiclePark
    {
        private const int DefaultTicketSymbolCount = 20;
        private const char DefaultTicketOuterSymbol = '*';
        private const char DefaultTicketInnerSymbol = '-';

        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            this.VehicleParkLayout = new VehicleParkLayout(numberOfSectors, placesPerSector);
            this.VehicleParkData = new VehicleParkData(numberOfSectors);
        }

        public VehicleParkData VehicleParkData { get; set; }

        public VehicleParkLayout VehicleParkLayout { get; set; }
        
        public string InsertCar(Car car, int sector, int place, DateTime startTime)
        {
            return this.InsertVehicle(car, sector, place, startTime);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime startTime)
        {
            return this.InsertVehicle(motorbike, sector, place, startTime);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime startTime)
        {
            return this.InsertVehicle(truck, sector, place, startTime);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = this.VehicleParkData.VehiclesByLicensePlate.FirstOrDefault(v => v.Key == licensePlate).Value;
            if (vehicle == null)
            {
                 return string.Format(Messages.NonExistingLicensePlate, licensePlate);
            }

            var startTime = this.VehicleParkData.VehicleByStartTime.First(v => v.Key.LicensePlate == licensePlate).Value;
            var totalHours = (int)Math.Round((endTime - startTime).TotalHours);
            var ticket = this.GetTicket(vehicle, totalHours, money);

            this.RemoveVehicleFromParkData(vehicle);

            return ticket;
        }
        
        public string GetStatus()
        {
            var places = this.VehicleParkData
                .SpacesCount
                .Select((sector, index) => string.Format(
                    Messages.SectorStatus,
                    index + 1,
                    sector, 
                    this.VehicleParkLayout.SectorPlacesPerSector,
                    Math.Round((double)sector / this.VehicleParkLayout.SectorPlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = this.VehicleParkData.VehiclesByLicensePlate.FirstOrDefault(v => v.Key == licensePlate).Value;

            if (vehicle == null)
            {
                return string.Format(Messages.NonExistingLicensePlate, licensePlate);
            }

            return this.FormatVehiclePrintData(new[] { vehicle });
        }

        public string FindVehiclesByOwner(string owner)
        {
            var vehicles = this.VehicleParkData.VehicleByStartTime
                .Where(v => v.Key.Owner == owner)
                .OrderBy(v => v.Value)
                .ThenBy(v => v.Key.LicensePlate)
                .Select(v => v.Key)
                .ToList();

            if (!vehicles.Any())
            {
                return string.Format(Messages.NonExistingVehicle, owner);
            }

            return string.Join(Environment.NewLine, this.FormatVehiclePrintData(vehicles));
        }

        private string InsertVehicle(IVehicle vehicle, int sector, int place, DateTime startTime)
        {
            if (sector > this.VehicleParkLayout.NumberOfSectors)
            {
                return string.Format(Messages.InvalidSector, sector);
            }

            if (place > this.VehicleParkLayout.SectorPlacesPerSector)
            {
                return string.Format(Messages.InvalidPlace, place, sector);
            }

            if (this.VehicleParkData.ParkPlaces.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format(Messages.PlaceAlreadyOccupied, sector, place);
            }

            if (this.VehicleParkData.VehiclesByLicensePlate.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(Messages.DuplicateLicensePlate, vehicle.LicensePlate);
            }

            this.AddVehicleToParkData(vehicle, sector, place, startTime);

            return string.Format(Messages.ParkedVehicle, vehicle.GetType().Name, sector, place);
        }

        private void AddVehicleToParkData(IVehicle vehicle, int sector, int place, DateTime startTime)
        {
            this.VehicleParkData.VehiclesInParkPlaces[vehicle] = string.Format("({0},{1})", sector, place);
            this.VehicleParkData.ParkPlaces[string.Format("({0},{1})", sector, place)] = vehicle;
            this.VehicleParkData.VehiclesByLicensePlate[vehicle.LicensePlate] = vehicle;
            this.VehicleParkData.VehicleByStartTime[vehicle] = startTime;
            this.VehicleParkData.VehiclesByOwner[vehicle.Owner].Add(vehicle);
            this.VehicleParkData.SpacesCount[sector - 1]++;
        }

        private void RemoveVehicleFromParkData(IVehicle vehicle)
        {
            var sector = int.Parse(this.VehicleParkData.VehiclesInParkPlaces[vehicle].Split(new[] { "(", ",", ")" }, StringSplitOptions.RemoveEmptyEntries)[0]);

            this.VehicleParkData.ParkPlaces.Remove(this.VehicleParkData.VehiclesInParkPlaces[vehicle]);
            this.VehicleParkData.VehiclesInParkPlaces.Remove(vehicle);
            this.VehicleParkData.VehiclesByLicensePlate.Remove(vehicle.LicensePlate);
            this.VehicleParkData.VehicleByStartTime.Remove(vehicle);
            this.VehicleParkData.VehiclesByOwner.Remove(vehicle.Owner, vehicle);
            this.VehicleParkData.SpacesCount[sector - 1]--;
        }

        private string GetTicket(IVehicle vehicle, int endTime, decimal money)
        {
            var ticket = new StringBuilder();
            ticket.AppendLine(new string(DefaultTicketOuterSymbol, DefaultTicketSymbolCount))
                .AppendLine(vehicle.ToString())
                .AppendLine(string.Format("at place {0}", this.VehicleParkData.VehiclesInParkPlaces[vehicle]))
                .AppendLine(string.Format("Rate: ${0:F2}", vehicle.ReservedHours * vehicle.RegularRate))
                .AppendLine(string.Format(
                    "Overtime rate: ${0:F2}",
                    endTime > vehicle.ReservedHours ? (endTime - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                .AppendLine(string.Format(new string(DefaultTicketInnerSymbol, DefaultTicketSymbolCount)))
                .AppendLine(string.Format(
                    "Total: ${0:F2}",
                    (vehicle.ReservedHours * vehicle.RegularRate) + (endTime > vehicle.ReservedHours ? (endTime - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine(string.Format("Paid: ${0:F2}", money))
                .AppendLine(string.Format(
                    "Change: ${0:F2}",
                    money - ((vehicle.ReservedHours * vehicle.RegularRate) + (endTime > vehicle.ReservedHours ? (endTime - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))))
                .Append(new string(DefaultTicketOuterSymbol, DefaultTicketSymbolCount));

            return ticket.ToString();
        }

        private string FormatVehiclePrintData(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(
                Environment.NewLine,
                vehicles.Select( 
                    v => string.Format(
                        Messages.VehicleStatus, 
                        v.ToString(), 
                        Environment.NewLine,
                        this.VehicleParkData.VehiclesInParkPlaces[v])));
        }
    }
}