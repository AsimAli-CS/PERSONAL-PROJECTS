using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace LocationLibrary
{
   public class Location
    {
        private float latitude;
        private float longitude;

        public Location(float lat, float lon)
        {
            latitude = lat;
            longitude = lon;
        }

        public Location() { }

        public float Latitude
        {
            get { return latitude; }
            set { latitude = value; }
        }

        public float Longitude
        {
            get { return longitude; }
            set { longitude = value; }
        }

        public void setLocation(float lat, float lon)
        {
            latitude = lat;
            longitude = lon;
        }

    }

}