namespace VehicleParkSystem.Models.Vehicle
{
    public class Motorbike : Vehicle
    {
        private const decimal DefaultRegularRate = 1.35M;
        private const decimal DefaultOvertimeRate = 3M;

        public Motorbike(string licensePlate, string owner, int reservedHours) 
            : base(licensePlate, owner, reservedHours, DefaultRegularRate, DefaultOvertimeRate)
        {
        }
    }
}