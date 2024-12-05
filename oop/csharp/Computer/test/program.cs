using System;
using System.Collections.Generic;
using System.IO;
using compLibs;
using compLibs.Servers;


public class Program {
    static Random random = new Random();
    static List<int> UsedNumbers = new List<int>();
    static StreamWriter log;                                    // Declaration of log
    static List<Computer> network = new List<Computer>();

    //How teacher creates new servers                                                                            

    //Server zero = new Server ("zero", "192.34.0.0","Web Server");
    //Server omega = new Server ("omega", "192.34.1.0","DHCP");

    static string getNum() {
        if (UsedNumbers.Count == 0) {
            for (int i = 1; i <= 254; i++) {
                UsedNumbers.Add(i);
            }
        }

        int index = random.Next(UsedNumbers.Count);
        int num = UsedNumbers[index];
        UsedNumbers.RemoveAt(index);

        return num.ToString();
    }

//Logs the start of the server and displays a message

    public static void StartServer() {
        log.WriteLine($"[Server Started]: {DateTime.Now}");
        
        Console.WriteLine("Server started and logged in the file.");
    }
//Creates and starts a specific number of computers logging each one of them

    public static void StartComputers(int count) {
        for (int i = 0; i < count; i++) {
            var biosName = "comp" + i.ToString();
            var ipAddress = "10.0.192." + getNum();
            network.Add(new Computer("Default", biosName, ipAddress));
            //network.Add(new Server("Computer", biosName, ipAddress, "General Purpose"));
            log.WriteLine($"[Computer Started]: BiosName: {biosName}, IpAddress: {ipAddress}, Time: {DateTime.Now}");
            
        }
        Console.WriteLine($"{count} Computers added.");
    }
//Displays the information about the devices in the network which have been previously started

    public static void DisplayComputers() {
        foreach (var computer in network) {
            // Type = type = comp.GetType();
            //Console.Written(Type);
            // string stringType =  type.ToString();
            if (computer is Server server) {
                server.ShowInfo();
                Console.WriteLine($"\tType: {server.Type}");
            }
            else{
            computer.ShowInfo();
            }
            // if(stringType == "Server")
               // {
               // Server serv = (Server) comp  CASTING
               // System.Console.WriteLine("\t{0}", serv.kindofserver) 
               // }
        }
    }

//Shuts down a specific computer by itś IP address

    public static void ShutDownComputer(string ipAddress) {
        bool found = false;
        foreach (var computer in network) {
            if (computer.IpAddress == ipAddress) {
                computer.ShutDown();
                log.WriteLine($"[Computer Shut Down]: IpAddress: {ipAddress}, Time: {DateTime.Now}");
            
                Console.WriteLine($"Computer {ipAddress} shut down.");
                found = true;
                break;
            }
        }
        if (!found) {
            Console.WriteLine("Could not find the computer.");
        }
    }

//Shuts down all computers in the network

    public static void ShutDownAllComputers() {
        foreach (var computer in network) {
            computer.ShutDown();
            log.WriteLine($"[All Computers Shut Down]: Time: {DateTime.Now}");
            
        }
        Console.WriteLine("All computers have been shut down.");
    }

//Flushes the log to ensure all data is saved 
    public static void SeeLog() {
        log.Flush();                                        
        Console.WriteLine("Log saved to 'log.txt'.");
    }

    public static void Main() {
        // Initialize log
        log = File.AppendText("log.txt");

        bool on = true;
        while (on) {
            Console.WriteLine("Program Menu:");
            Console.WriteLine("1. Start Server");
            Console.WriteLine("2. Start Computers");
            Console.WriteLine("3. Display Computers");
            Console.WriteLine("4. Shut down computer");
            Console.WriteLine("5. Shut down all computers");
            Console.WriteLine("6. See the log");
            Console.WriteLine("7. Shut down server");
            Console.WriteLine("8. Quit");
            Console.WriteLine("Select an option:");

            string options = Console.ReadLine();

            switch (options) {
                case "1":
                    StartServer();
                    break;
                case "2":
                    Console.WriteLine("How many computers do you want to start?");
                    if (int.TryParse(Console.ReadLine(), out int count)) {
                        StartComputers(count);
                    }
                    break;
                case "3":
                    DisplayComputers();
                    break;
                case "4":
                    Console.WriteLine("Which computer do you want to shut down?");
                    string ipAddress = Console.ReadLine();
                    ShutDownComputer(ipAddress);
                    break;
                case "5":
                    ShutDownAllComputers();
                    break;
                case "6":
                    SeeLog();
                    break;
                case "7":
                    Console.WriteLine("This method is not available yet.");
                    break;
                case "8":
                    on = false;
                    log.WriteLine($"[Program Terminated]: {DateTime.Now}");
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
        log.Flush();
        // Close log file before exiting
        log.Close();
    }
}