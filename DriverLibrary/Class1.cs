
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
using LocationLibrary;
using VehicleLibrary;

namespace DriverLibrary
{
    public class Driver
    {

        private int DriverID;
        private string name;
        private int age;
        private string gender;
        private string address;
        private string phone_No;
        private Location curr_location;
        private Vehicle vehicle;
        private List<int> rating;
        private bool availability;

        public Driver(int id, string n, int a, string g, string add, string p, string t, string m, string l)
        {

            DriverID = id;
            name = n;
            age = a;
            gender = g;
            address = add;
            phone_No = p;
            Vehicle v = new Vehicle(t, m, l);
            vehicle = v;
            rating = new List<int>();
            availability = true;
            curr_location = new Location();
        }

        public void updateDetail(int id, string n, int a, string g, string add, string p, string t, string m, string l)
        {
            DriverID = id;
            name = n;
            age = a;
            gender = g;
            address = add;
            phone_No = p;
            availability = true;
            if (t != null)
            { vehicle.MyType = t; }

            if (m != null)
            { vehicle.MyModel = m; }

            if (l != null)
            { vehicle.MyLicensePlate = l; }


        }
        public Driver()
        {
            curr_location = new Location();
            vehicle = new Vehicle();
            rating = new List<int>();
        }

        public int MyDriver_ID
        {
            get
            {
                return DriverID;
            }
            set
            {
                DriverID = value;
            }
        }
        public string MyName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int MyAge
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        public string MyGender
        {
            get
            {
                return gender;
            }
            set
            {
                gender = value;
            }
        }

        public string MyAddress
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }

        public string MyPhone_No
        {
            get
            {
                return phone_No;
            }
            set
            {
                phone_No = value;
            }
        }



        public Location MyLocation
        {
            get
            {
                return curr_location;
            }
            set
            {
                curr_location = value;
            }
        }

        public Vehicle MyVehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value;
            }

        }




        public List<int> MyRating
        {
            get
            {
                return rating;
            }
            set
            {
                rating = value;
            }
        }

        public bool MyAvailability
        {
            get
            {
                return availability;
            }
            set
            {
                availability = value;
            }
        }


        public void updateAvailability()
        {
            Console.Write("Enter you Availabilty status T/F :");
            Console.ForegroundColor = ConsoleColor.Green;
            string avail = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            bool check = true;
           
            if (avail != "")
            {
                if (avail == "T") { check = true; }
                if (avail == "t") { check = true; }
                if (avail == "f") { check = false; }
                if (avail == "f") { check = false; }
            }



            Console.WriteLine();
            if (avail != "")
            {
                availability = check;
                Console.WriteLine();
                Console.WriteLine("CONGRATULATION: Status is Successfully Updated !!!");
                 Console.WriteLine();
            }
            else
            {
                Console.Write("Plaese Enter you Availabilty status T/F :");
                Console.WriteLine();
                avail = Console.ReadLine();
            }

        }

        public double getRating()
        {
            if (MyRating.Count == 0)
            {
                return 0;
            }

            int overAll_List = 0;
            foreach (int r in MyRating)
            {
                overAll_List = overAll_List + r;
            }

            return (double)overAll_List / MyRating.Count;



        }

        public void updateLocation()
        {
            Console.Write("Do you want to change your Current Location (T/F):");
            Console.ForegroundColor = ConsoleColor.Green;
            string C_loc = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            if (C_loc == "T" || C_loc == "t")
            {

                Console.Write("Enter your update location latitude ");
                Console.ForegroundColor = ConsoleColor.Green;
                string curr_lat1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                float curr_lat = float.Parse(curr_lat1);


                Console.Write("Enter your update location longitude ");
                Console.ForegroundColor = ConsoleColor.Green;
                string curr_long1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                float curr_long = float.Parse(curr_long1);
                Console.WriteLine();
                Console.WriteLine("CONGRATULATION: Location is Successfully Updated !!!");
                Console.WriteLine();
                curr_location.setLocation(curr_lat, curr_long);

            }
            else
            {
                return;
            }


        }



    }
}