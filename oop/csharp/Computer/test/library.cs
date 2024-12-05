using System;
using System.Collections.Generic;

namespace compLibs
{
    public abstract class Device                        //interface IDevice{
                                                        // void StartDevice();
                                                        //void ShutDown() ;
                                                        //}
    {

        protected string _name;

//Constructor to initialize the device's name

        public Device(string name)
        {
            _name = name;
        }
//Abstract methods to be implemented by derived class

        public abstract void StartDevice();             // public virtual void StartDevice()
        public abstract void ShutDown();                // public virtual void ShutDown()
    }

//Computer class is derived from the Device class

    public  class Computer : Device
    {
        
        private string biosName;
        private string ipAddress;
        private static int counter = 0;

      
        public string BiosName
        {
            get { return this.biosName; }
            set { this.biosName = value; }
        }

        public string IpAddress
        {
            get { return this.ipAddress; }
            set { this.ipAddress = value; }
        }

        // Constructor
        public Computer(string name, string biosname,string ipAddress)  : base(name)      
        {
            BiosName = biosName;
            IpAddress = ipAddress;
            counter++;
        }

// Deafault constructor for a computer with an "Unkown" name

        public Computer() : base("Unknown")
        {
            counter++;
        }

//To get the number of computers created

        public static int GetCompNum()
        {
            return counter;
        }

        public override void StartDevice()
        {
            Console.WriteLine("Device started.");
        }

        public override void ShutDown()
        {
            IpAddress = null;
            Console.WriteLine("**************** !!!! **************");
            Console.WriteLine("Are you sure you want to shut down this server? (YES/n)");
            string confirm = Console.ReadLine();
            if (confirm == "YES"){
                Console.WriteLine("The comp {0} is shutting down !!!", this._name);
            }
            Console.WriteLine("Device shut down.");
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Name: {_name}, BiosName: {BiosName}, IpAddress: {IpAddress}");
        }
    }
}