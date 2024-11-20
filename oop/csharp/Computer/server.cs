using System;
using System.Collections.Generic;

namespace compLibs
{
    public class Computer
    {
        private string _BIOSname;
        private string _ipadress;
        private static int _counter = 0;

        // Constructor
        public Computer(string bn, string ip)
        {
            this._BIOSname = bn;
            this._ipadress = ip;
            _counter++;
        }

        // Default constructor
        public Computer() 
        {
            _counter++;
        }

        // Properties
        public string BiosName
        {
            get { return this._BIOSname; }
            set { this._BIOSname = value; }
        }

        public string IPAddress
        {
            get { return this._ipadress; }
            set { this._ipadress = value; }
        }

        // Static method to get the number of computers
        public static int getCompsNum()
        {
            return _counter;
        }

        // Method to generate a random number for IP
        public static string getNum()
        {
            Random random = new Random();
            int num = random.Next(2, 255);  // Generate a random number between 2 and 254
            return num.ToString();
        }

        // Start computer with a given IP address
        public virtual void StartComputer(string addr1, string addr2)
        {
            IPAddress = addr1 + addr2;
        }

        // Assign unique addresses to computers
        public void addresses(List<string> dhcpAddresses, int N)
        {
            int count = 0;
            string piece = "";

            while (count < N)
            {
                piece = getNum();
                if (!dhcpAddresses.Contains(piece))
                {
                    dhcpAddresses.Add(piece);
                    count++;
                }
            }
        }

        // Show info of the computer
        public void ShowInfo()
        {
            Console.WriteLine($"BiosName: {BiosName}, IPAddress: {IPAddress}");
        }
    }

    // Server class inherits from Computer
    
    public class Server : Computer
    {
        private string _type;

        // Property to define the type of server
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        // Constructor for Server class
        public Server(string bn, string ip, string type) : base(bn, ip)
        {
            this._type = type;
        }

        public Server() { }

        // Override StartComputer to implement server-specific logic

        public override void StartComputer(string addr1, string addr2)
        {
            IPAddress = addr1 + addr2;  // Custom logic for starting a server
        }
    }
}
