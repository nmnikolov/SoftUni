namespace MusicShopManager.Engine.Factories
{
    using Interfaces;
    using Interfaces.Engine;
    using Models;

    public class MusicShopFactory : IMusicShopFactory
    {
        public IMusicShop CreateMusicShop(string name)
        {
            return new MusicShop(name);
        }
    }
}
