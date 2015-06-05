namespace VehicleParkSystem.Models
{
    using System;
    using Engine;

    public class VehicleParkLayout
    {
        private int sectorPlacesPerSector;
        private int numberOfSectors;

        public VehicleParkLayout(int numberOfSectors, int sectorPlacesPerSector)
        {
            this.NumberOfSectors = numberOfSectors;
            this.SectorPlacesPerSector = sectorPlacesPerSector;
        }

        public int NumberOfSectors
        {
            get
            {
                return this.numberOfSectors;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Messages.Possitive, "number of sectors"));
                }

                this.numberOfSectors = value;
            }
        }

        public int SectorPlacesPerSector
        {
            get
            {
                return this.sectorPlacesPerSector;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(Messages.Possitive, "number of places per sector"));
                }

                this.sectorPlacesPerSector = value;
            }
        }
    }
}