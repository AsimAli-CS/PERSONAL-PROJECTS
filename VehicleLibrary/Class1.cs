
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

namespace VehicleLibrary
{
   public class Vehicle
    {
        private string type;
        private string model;
        private string licensePlate;

        public Vehicle()
        {
            type = "";
            model = "";
            licensePlate = "";
        }
        public Vehicle(string t, string m, string l)
        {
            type = t;
            model = m;
            licensePlate = l;
        }

        public string MyType
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public string MyModel
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }

        public string MyLicensePlate
        {
            get
            {
                return licensePlate;
            }
            set
            {
                licensePlate = value;
            }
        }


    }

}