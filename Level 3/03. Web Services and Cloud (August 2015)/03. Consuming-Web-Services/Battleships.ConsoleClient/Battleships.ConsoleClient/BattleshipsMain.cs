namespace Battleships.ConsoleClient
{
    using System.Globalization;
    using System.Threading;
    using Engine;

    public class BattleshipsMain
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var engine = new BattleshipsEngine();
            engine.Run();
        }
    }
}
