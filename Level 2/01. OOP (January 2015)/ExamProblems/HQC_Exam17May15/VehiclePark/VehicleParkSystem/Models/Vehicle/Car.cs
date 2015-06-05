namespace VehicleParkSystem.Models.Vehicle
{
    public class Car : Vehicle
    {
        private const decimal DefaultRegularRate = 2M;
        private const decimal DefaultOvertimeRate = 3.5M;

        public Car(string licensePlate, string owner, int reservedHours) 
            : base(licensePlate, owner, reservedHours, DefaultRegularRate, DefaultOvertimeRate)
        {
        }
    }
}