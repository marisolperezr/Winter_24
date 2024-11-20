using System;
using System.Collections.Generic;

namespace compLibs
{
    public abstract class Device
    {

        protected string _name;

        public Device(string name)
        {
            _name = name;
        }

        public abstract void StartDevice();
        public abstract void ShutDown();
    }

    public class Computer : Device
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
        public Computer(string name, string biosName,string ipAddress) : base(name)
        {
            BiosName = biosName;
            IpAddress = ipAddress;
            counter++;
        }

        // Constructor default
        public Computer() : base("Unknown")
        {
            counter++;
        }

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
            Console.WriteLine("Device shut down.");
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {_name}, BiosName: {BiosName}, IpAddress: {IpAddress}");
        }
    }
}
