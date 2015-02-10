namespace GalacticGPS
{
    using System;

    public struct Location
    {
        private double latitude;

        private double longitude;

        public Location(double latitude, double longitude, Planet planet)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Planet = planet;
        }

        public Planet Planet { get; set; }

        public double Latitude {
            get { return this.latitude; }
            set
            {
                if (value < -90 || value > 90)
                {
                    throw new ArgumentOutOfRangeException("latitude", "Latitude should be in the range [-90 ... 90].");
                }

                this.latitude = value;
            }
        }

        public double Longitude { get { return this.longitude; }
            set
            {
                if (value < -180 || value > 180)
                {
                    throw new ArgumentOutOfRangeException("longitude", "Longitude should be in the range [-180 ... 180].");
                }

                this.longitude = value;
            } 
        }

        public override string ToString()
        {
            String result = String.Format("{0}, {1} - {2}", this.Latitude, this.Longitude, this.Planet);

            return result;
        }
    }
}