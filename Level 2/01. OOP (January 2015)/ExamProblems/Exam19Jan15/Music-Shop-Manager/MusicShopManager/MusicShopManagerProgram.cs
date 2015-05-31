namespace MusicShopManager
{
    using System.Globalization;
    using System.Threading;
    using Engine;

    public class MusicShopManagerProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            MusicShopEngine.Instance.Start();
        }
    }
}
