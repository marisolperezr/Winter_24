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
    public void ShutDown(string ip) {
        IpAddress = ip;
        IpAddress = null;

    }
    public void ShowInfo() {
        Console.WriteLine($"BiosName: {BiosName}, IpAddress: {IpAddress}");
    }
}

public class Program
{
    static Random random = new Random();            // Move Random out of the method to avoid creating multiple instances

    // How to be sure no number is ever repeated

    // Create a list of already used numbers
    static List<int> UsedNumbers = new List<int>();

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

    public static void Main()  
    {
        Computer[] net = new Computer[4];
        for (int i = 0; i < net.Length; i++) {
            net[i] = new Computer("comp" + i.ToString(), "10.0." + getNum() + "." + getNum());
        }

        for (int i = 0; i < net.Length; i++) {
            Console.WriteLine("{0} --- {1}", net[i].BiosName, net[i].IpAddress);
        }

        // Creating objects using parameter constructor

        Computer computer1 = new Computer("Bios-Computer1", "192.168.1.1");
        Computer computer2 = new Computer("Bios-Computer2", "192.168.1.2");

        // Creating objects using default constructor

        Computer comp01 = new Computer();
        comp01.BiosName = "alfa";

        // If I use the method StartComputer to get the Ip Address

        string newip = "10.0." + getNum() + "." + getNum(); // generate an IP using getNum()
        comp01.StartComputer(newip);
        comp01.ShutDown(newip);
        
        Console.WriteLine(comp01.BiosName + " - " + comp01.IpAddress);
        Console.WriteLine("We have {0} computers!!", Computer.getCompNum());

        // Show ShowInfo

        computer1.ShowInfo();
        computer2.ShowInfo();
        comp01.ShowInfo();
    }
}
