using System;
using System.Collections.Generic;
using System.IO;
using compLibs;


public class Program {
    static Random random = new Random(); 
    static List<int> UsedNumbers = new List<int>(); 
    static StreamWriter log;                                    // Declaration of log 
    static List<Computer> network = new List<Computer>();


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


    public static void StartServer() {
        log.WriteLine($"[Server Started]: {DateTime.Now}");
        Console.WriteLine("Server started and logged in the file.");
    }


    public static void StartComputers(int count) {
        for (int i = 0; i < count; i++) {
            var biosName = "comp" + i.ToString();
            var ipAddress = "10.0.192." + getNum();
            network.Add(new Computer(biosName, ipAddress));
            log.WriteLine($"[Computer Started]: BiosName: {biosName}, IpAddress: {ipAddress}, Time: {DateTime.Now}");
            
        }
        Console.WriteLine($"{count} Computers added.");
    }

    public static void DisplayComputers() {
        foreach (var computer in network) {
            computer.ShowInfo();
        }
    }


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


    public static void ShutDownAllComputers() {
        foreach (var computer in network) {
            computer.ShutDown();
            log.WriteLine($"[All Computers Shut Down]: Time: {DateTime.Now}");
        }
        Console.WriteLine("All computers have been shut down.");
    }


    public static void SeeLog() {
        log.Flush();                                        // To make sure everything is written in log
        Console.WriteLine("Log saved to 'log.txt'.");
    }

    public static void Main() {
        // Initialize log
        log = File.CreateText("log.txt");

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

        // Close log
        log.Close();
    }
}
