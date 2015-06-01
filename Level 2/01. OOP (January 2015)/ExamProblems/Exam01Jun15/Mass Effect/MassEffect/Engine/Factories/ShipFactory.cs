namespace MassEffect.Engine.Factories
{
    using System;
    using System.Collections.Generic;
    using GameObjects.Enhancements;
    using GameObjects.Locations;
    using GameObjects.Ships;
    using Interfaces;

    public class ShipFactory
    {
        public IStarship CreateShip(StarshipType type, string name, StarSystem location, IEnumerable<Enhancement> enhancements)
        {
            switch (type)
            {
                case StarshipType.Frigate:
                    return new Frigate(name, location, enhancements);
                case StarshipType.Cruiser:
                    return new Cruiser(name, location, enhancements);
                case StarshipType.Dreadnought:
                    return new Dreadnought(name, location, enhancements);
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }
        }
    }
}
