using System;
using System.Collections.Generic;

namespace compLibs.Servers
{
//Abstract class server inherits from computer

    public abstract class Server : Computer
    {
        //private string _BIOSname;
        private string _ipadress;
        private string _type; 
        private static int _counter = 0;

        // Constructor
        public Server (string name,string biosName, string ipAdress, string type) : base (name, biosName, ipAdress)
        {
            this._type = type;
            _counter++;
        }

        //Default constructor for the server

        public Server()
        {
            _counter++;
        }

      // public string BiosName{
      //        get { return this._BIOSname; }
      //      set { this._BIOSname = value; }
      // }

       public string IPAddress{
           get { return this._ipadress; }
           set { this._ipadress = value; }
      }

        public string Type
        {
            get { return this._type; }
            set { this._type = value; }
        }
        // Method to get the total number os server instances created

        public static int GetServerComputerNum()
        {
            return _counter;
        }

        public static string GetRandomNum()
        {
            Random random = new Random();
            int num = random.Next(2, 255);
            return num.ToString();
        }

        public virtual void StartServerComputer(string addr1, string addr2)
        {
            IPAddress = addr1 + addr2;
        }

        public override void ShowInfo()
        {
            //Call the base class method to show common info
            base.ShowInfo();
            Console.WriteLine($"Server of type {_type} strated with IP: {_ipadress}");
        }
    }

    public class WebServer : Server
    {
        public WebServer(string name, string biosName, string ipAdress, string type)
            : base(name, biosName, ipAdress, type)
        {
        }
    }   
}
