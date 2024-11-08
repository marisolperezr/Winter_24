using System;
using System.Collections.Generic;                   // Included this for List<int> 

public class Computer
{
    // Attributes
    private string biosName; 
    private string ipAddress; 
    private static int counter = 0;

    public string BiosName {
        get {
            return this.biosName; 
        }
        set {
            this.biosName = value; 
        }
    }

    public string IpAddress {
        get {
            return this.ipAddress; 
        }
        set {
            this.ipAddress = value; 
        }
    }

    // Constructor
    public Computer(string biosName, string ipAddress)
    {
        BiosName = biosName;
        IpAddress = ipAddress;
        counter++;
    }

    // Default constructor
    public Computer() {
        counter++;
    }

    public static int getCompNum() {
        return counter;
    } 

    public void StartComputer(string ip) {
       IpAddress = ip;
    }
    public void ShutDown() {
        IpAddress = null;

    }
    public void ShowInfo() {
        Console.WriteLine($"BiosName: {BiosName}, IpAddress: {IpAddress}");
    }
}
public class Program{
    static Random random = new Random();            // Move Random out of the method to avoid creating multiple instances
    static List<int> UsedNumbers = new List<int>(); // Create a list of already used numbers

    static string getNum() {                        // Static method to generate random numbers
        if (UsedNumbers.Count == 0) {
            for (int i = 1; i <= 254; i++) {        // At first, my list is empty so I fill it with all the values between 1 and 254
                UsedNumbers.Add(i);
            }
        }

        int index = random.Next(UsedNumbers.Count); // UsedNumbers count is the total number of numbers I have in my list UsedNumbers. So I generate a random number with random.next between 0 and the count of UsedNumbers
        int num = UsedNumbers[index];               // When I have the number, for example, if it is 3 we would have int num=UsedNumbers[3] and the number would be the one on the third position
        UsedNumbers.RemoveAt(index);                // I erase the selected number so it’s no longer available

        return num.ToString();                      // Returns the selected number as a string
    }


    // static Computer[] net; 

    static List<Computer> network = new List<Computer>();
    public static void Ping(string ipAddress) {
        bool encontrado = false;
        foreach (var computer in network) {        
            if (ipAddress == computer.IpAddress) {
                encontrado = true; 
                Console.WriteLine(" bytes=32 time<1ms TTL=64");
                break;
            }
        }
        if (encontrado == false) { 
            Console.WriteLine("Time gone");
        }
    }

    public static void StartServer(){
        Console.WriteLine("This method is not available yet");
    }

    public static void StartComputers(int count){
        for(int i=0; i<count; i++){
            network.Add(new Computer("comp" + i.ToString(), "10.0.192."+getNum()));
        }
        Console.WriteLine($"{count} Computers added ");
    }

    public static void DisplayComputers (){
        foreach ( var computer in network){
            computer.ShowInfo();
        } 
    }

    public static void ShutDownComputer(string ipAddress ){
        bool found = false;
        foreach ( var computer in network){
            if (computer.IpAddress == ipAddress){
                computer.ShutDown();
                Console.WriteLine($"Computer {ipAddress} shutted down ");
                found = true;
                break;
            }
        }
            if (!found){
                Console.WriteLine("Could not find the computer");
            }

    }
    public static void ShutDownAllComputers(){
        foreach ( var computer in network){
            computer.ShutDown();
        }
        Console.WriteLine("All computers have been shutted down.");
    }
    public static void SeeLog(){
        Console.WriteLine("This method is not available yet");
    }
    public static void ShutDownServer(){
        Console.WriteLine("This method is not available yet");
    }
    public static void Main(){
    
    bool on = true;
    while(on){
        Console.WriteLine("Program Menu:");
        Console.WriteLine("1.Start Server");
        Console.WriteLine("2.Start Computers");
        Console.WriteLine("3.Display Computers");
        Console.WriteLine("4.Shut down computer");
        Console.WriteLine("5.Shut down all computers");
        Console.WriteLine("6.See the log");
        Console.WriteLine("7.Shut down server");
        Console.WriteLine("8.Quit");
        Console.WriteLine("Select an option:");

        string options = Console.ReadLine();

        switch (options){
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
                ShutDownServer();
                break;
            case "8":
                on = false;
                Console.WriteLine ("Bye!");
                break;
            default: 
                Console.WriteLine("Invalid option.Try again");
                break;            
        }
    }
 }

}