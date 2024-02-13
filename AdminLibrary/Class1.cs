using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Serialization;
using DriverLibrary;

namespace AdminLibrary
{
    public class Admin
    {
        private List<Driver> drivers;

        public Admin()
        {
            drivers = new List<Driver>();
        }

        public List<Driver> Drivers
        {
            get
            {
                return drivers;
            }
            set
            {
                drivers = value;
            }
        }

        public void addDriver()
        {
            Console.Write("Enter the Driver ID: ");
            
            int id = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                   
                    id = int.Parse(input);
                   
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.Write("Invalid input. Enter the Driver ID again in digits:");

                }
            }

            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string n = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            //int a = 21;
            //int id = 121;

            Console.Write("Enter your age: ");

            int a = 0;
            
            while (a>=0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                string input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                try
                {
                    a = int.Parse(input);
                    if (a < 0)
                    {
                        throw new Exception("a cannot be negative");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine();
                    Console.Write("Invalid input. Enter the Age again in digits:");

                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.Write("Invalid input. Enter the Age again in digits:");
                }
            }


            Console.Write("Enter your gender: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string g = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            // string g = "male";

            Console.Write("Enter your address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string add = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            // string add = "4/12 sodiwal";

            Console.Write("Enter your phone no in 11 digits: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string p = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (p.Length != 11)
            {
                Console.Write("Enter your phone no in 11 digits: ");
                Console.ForegroundColor = ConsoleColor.Green;
                p = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            // string p = "12345678910";

            Console.Write("Enter your vehicle type: Car / Bike / Rickshaw: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string t = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            //string t = "";
            //string t = "bike";

            while (t != "car" && t != "bike" && t != "rickshaw")
            {
                Console.Write("Please Enter the Vechicle from car / rickshaw / bike: ");
                Console.ForegroundColor = ConsoleColor.Green;
                t = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }



            Console.Write("Enter your vehicle model:");
            Console.ForegroundColor = ConsoleColor.Green;
            string m = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            //string m = "125";


            Console.Write("Enter your vehicle lisencePlate:");
            Console.ForegroundColor = ConsoleColor.Green;
            string l = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            //string l = "1212";
            Console.WriteLine();

            Driver d = new Driver(id, n, a, g, add, p, t, m, l);

            drivers.Add(d);

        }

        public void updatDriver()
        {
            Console.Write("Show the available Driver IDs : ");

            foreach (Driver driver in drivers)
            {
                Console.Write(driver.MyDriver_ID + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Enter Driver_ID for Updation: ");
            int id = int.Parse(Console.ReadLine());
            Driver drive = null;

            Console.WriteLine();


            drive = drivers.Find(d => d.MyDriver_ID == id);
            int count = 0;
            if (drive != null)
            {
                count++;

                Console.Write("Want to change your Drive ID: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string id1 = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int id2;
                if (id1 == "")
                {
                    id2 = drive.MyDriver_ID;
                }
                else
                {
                    id2 = int.Parse(id1);

                }


                Console.Write("Want to change Driver name: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string n = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (n == "") { n = drive.MyName; }

                Console.Write("Want to change Driver age: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string age = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                int a = 0;
                if (age == "")
                {
                    a = drive.MyAge;
                }
                else
                {
                    a = int.Parse(age);

                }

                Console.Write("Want to change Driver gender: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string g = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (g == "") { g = drive.MyGender; }

                Console.Write("Want to change Driver address: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string add = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (add == "") { add = drive.MyAddress; }

                Console.Write("Want to change Driver phone no: ");
                Console.ForegroundColor = ConsoleColor.Green;
                string p = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
                if (p == "") { p = drive.MyPhone_No; }

                Console.Write("Want to change Driver vehicle type:");
                Console.ForegroundColor = ConsoleColor.Green;
                string t = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;


                Console.Write("Want to change Driver vehicle model:");
                Console.ForegroundColor = ConsoleColor.Green;
                string m = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                Console.Write("Want to change Driver vehicle lisencePlate:");
                Console.ForegroundColor = ConsoleColor.Green;
                string l = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                drive.updateDetail(id2, n, a, g, add, p, t, m, l);
                Console.WriteLine();
                Console.WriteLine("CONGRATULATION: Driver is Successfully Updated !!!");
                Console.WriteLine();



            }
            if (count == 0)
            {
                Console.WriteLine("SADLY :) Driver does not exsist ");
                Console.WriteLine();

            }

        }

        public void RemoveDriver()
        {
            Console.Write("Show the available Driver IDs : ");

            foreach (Driver driver in drivers)
            {
                Console.Write(driver.MyDriver_ID + " ");

            }

            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Which Driver you want to remove Enter the ID please : ");
            Console.ForegroundColor = ConsoleColor.Green;
            int rem = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            int match = 0;


            Driver drive = drivers.Find(d => d.MyDriver_ID == rem);
            int count = 0;
            if (drive != null)
            {
                count++;
                for (int i = 0; i <= drivers.Count; i++)
                {
                    if (drivers[i].MyDriver_ID == rem)
                    {
                        count++;
                        drivers.RemoveAt(i);
                        Console.WriteLine("CONGRATULATION: Driver is Successfully Removed !!!");
                        Console.WriteLine();
                        break;
                    }

                }
            }
            if (count == 0)
            {
                Console.WriteLine("SADLY :) Driver does not exsist ");
                Console.WriteLine();
            }





        }

        public void search_The_Driver()
        {
            Console.Write("Enter your ID: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string id1 = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            int id2;
            if (id1 == "")
            {
                id2 = -1;
            }
            else
            {
                id2 = int.Parse(id1);

            }
            //int id2 = 10;

            Console.Write("Enter your name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string n = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (n == "") { n = ""; }
            //string n = "ali";

            Console.Write("Enter your age: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string age = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            int a = 0;
            if (age == "")
            {
                a = -1;
            }
            else
            {
                a = int.Parse(age);

            }
            //int a = 21;

            Console.Write("Enter your gender: ");           

            Console.ForegroundColor = ConsoleColor.Green;
            string g = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (g == "") { g = ""; }
            //string g = "male";

            Console.Write("Enter your address: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string add = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (add == "") { add = ""; }
            //string add = "11/12 street";

            Console.Write("Enter your phone no: ");
            Console.ForegroundColor = ConsoleColor.Green;
            string p = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (p == "") { p = ""; }
            //string p = "03014545624";

            Console.Write("Enter your vehicle type:");
            Console.ForegroundColor = ConsoleColor.Green;
            string t = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (t == "") { t = ""; }
            //string t = "car";

            Console.Write("Enter your vehicle model:");
            Console.ForegroundColor = ConsoleColor.Green;
            string m = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (m == "") { m = ""; }
            //string m = "2022";

            Console.Write("Enter your vehicle lisencePlate:");
            Console.ForegroundColor = ConsoleColor.Green;
            string l = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            if (l == "") { l = ""; }
            //string l = "4562";

            searchDriver(id2, n, a, g, add, t, m, l);



        }
        public void searchDriver(int id, string name, int age, string gender, string address, string vehicleType, string vehicleModel, string vehicleLicensePlate)
        {
            List<Driver> search = new List<Driver>();
            foreach (Driver driver in drivers)
            {
                bool check = true;
                if (id != -1)
                {
                    if (driver.MyDriver_ID != id)
                    {
                        check = false;
                    }
                }
                if (name != "")
                {
                    if (driver.MyName != name) { check = false; }
                }
                if (age != -1)
                {
                    if (driver.MyAge != age) { check = false; }
                }
                if (gender != "")
                {
                    if (driver.MyGender != gender) { check = false; }
                }
                if (address != "")
                {
                    if (driver.MyAddress != address) { check = false; }
                }
                if (vehicleType != "")
                {
                    if (driver.MyVehicle.MyType != vehicleType) { check = false; }
                }
                if (vehicleModel != "")
                {
                    if (driver.MyVehicle.MyModel != vehicleModel) { check = false; }
                }
                if (vehicleLicensePlate != "")
                {
                    if (driver.MyVehicle.MyLicensePlate != vehicleLicensePlate) { check = false; }
                }
                if (check == true)
                {
                    search.Add(driver);
                }
            }
            Console.WriteLine();
            Console.WriteLine("----------------------:Search Results:----------------------");
            Console.WriteLine();
            int count = 0;

            if (id == -1 || id != -1)
            {
                //Console.Write("DriverID         ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "DriverID");
            }
            if (name==""||name != "")
            {
                //Console.Write("Name           ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "Name ");
            }

            if (age == -1 || age != -1)
            {


                //Console.Write("Age           ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "Age ");
            }

            if (gender == "" || gender != "")
            {

                //Console.Write("Gender     ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "Gender ");
            }

            if (address == "" || address != "")
            {
               // Console.Write("Address        ");
                Console.Write(
                 format: "{0,-20}",
                 arg0: "Address ");
            }

            if (vehicleType == "" || vehicleType != "")
            {

               // Console.Write("VType          ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "VType ");
            }

            if (vehicleModel == "" || vehicleModel != "")
            {

               // Console.Write("VModel         ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "VModel  ");
            }

            if (vehicleLicensePlate == "" || vehicleLicensePlate != "")
            {
                //Console.Write("VPlate          ");
                Console.Write(
                 format: "{0,-10}",
                 arg0: "VPlate ");

            }

            Console.WriteLine();

            foreach (Driver driver in search)
            {
                 
                count++;
                if (id == -1 || id != -1 )
                {
                    //Console.Write(driver.MyDriver_ID + "               ");
                    Console.Write(
                    format: "{0,-10}",
                    arg0: driver.MyDriver_ID);

                }
                if (name == "" || name != "" )
                {
                    //string N = driver.MyName;
                    //string PadN = N.PadRight(15);
                    //Console.Write(PadN);

                    Console.Write(
                   format: "{0,-10}",
                   arg0: driver.MyName);
                }

                if (age == -1 || age != -1 )
                {


                    //Console.Write(driver.MyAge + "             ");
                    Console.Write(
                   format: "{0,-10}",
                   arg0: driver.MyAge);

                }

                if (gender == "" || gender != "")
                {
                    //string G = driver.MyGender;
                    //string PadG = G.PadRight(8);
                    //Console.Write( PadG);
                    Console.Write(
                  format: "{0,-10}",
                  arg0: driver.MyGender);
                }

                if (address == "" || address != "")
                {
                    //string A = driver.MyAddress;
                    //string PadA = A.PadRight(18);
                    //Console.Write( PadA);
                    Console.Write(
                  format: "{0,-20}",
                  arg0: driver.MyAddress);
                }

                if (vehicleType == "" || vehicleType != "")
                {
                    //string T = driver.MyVehicle.MyType;
                    //string PadT = T.PadRight(15);
                    //Console.Write( PadT);
                    Console.Write(
                  format: "{0,-10}",
                  arg0: driver.MyVehicle.MyType);
                }

                if (vehicleModel == "" || vehicleModel != "")
                {
                    //string M = driver.MyVehicle.MyModel;
                    //string PadM = M.PadRight(15);
                    //Console.Write( PadM);
                    Console.Write(
                  format: "{0,-10}",
                  arg0: driver.MyVehicle.MyModel);
                }

                if (vehicleLicensePlate == "" || vehicleLicensePlate != "") { 
                    //{
                    //    string L = driver.MyVehicle.MyLicensePlate;
                    //    string PadL = L.PadRight(15);
                    //    Console.Write( PadL);
                    Console.Write(
                      format: "{0,-10}",
                      arg0: driver.MyVehicle.MyLicensePlate);

            }

                Console.WriteLine();
                Console.WriteLine("----------------------------------------------------------------");
            }
            if (count == 0)
            {
                Console.WriteLine("Sadly :) Result are not found");
                Console.WriteLine();
                Console.WriteLine("-----------------------");
            }


        }

    }
}