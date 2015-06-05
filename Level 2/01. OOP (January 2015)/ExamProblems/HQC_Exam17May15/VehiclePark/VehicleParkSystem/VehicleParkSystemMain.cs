namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;
    using Engine;

    public static class VehicleParkSystemMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var engine = new VehicleParkSystemEngine();
            engine.Run();
        }
    }
}