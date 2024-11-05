/******************************************************************************

Maria Soledad Perez Ruiz

*******************************************************************************/


using System;

//namespace OOP_in_Csharp{   //cambiar el nombre al que queramos
public class Computer
{
    // Atributes
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

    public string IpAddress{
        get{
            return this.ipAddress; 
        }
        set{
            this.ipAddress = value; 
        }
    }

    // Constructor
    public Computer(string biosName, string ipAddress)
    {
        BiosName = biosName;
        IpAddress = ipAddress;
        counter ++;
    }

    // Default constructor
    public Computer() {
        counter++;
    }
    public static int getCompNum(){
        return counter;
    } 
    public void ShowInfo()
    {
        Console.WriteLine($"BiosName: {BiosName}, IpAddress: {IpAddress}");
    }
}

public class Program
{
    static Random random = new Random(); // Move Random out of the methor to avoid creating multiple instances

    static string getNum()              // Static method to generate random numbers
    {
        int num = random.Next(1, 255);  // Generates a number between min (inclusive) and  max (exclusive)
        return num.ToString();
    }

    public static void Main()  
    {
        Computer[] net = new Computer[4];
        for (int i = 0; i < net.Length; i++)
        {
            net[i] = new Computer("comp" + i.ToString(), "10.0." + getNum() + "." + getNum());
        }

        for (int i = 0; i < net.Length; i++)
        {
            Console.WriteLine("{0} --- {1}", net[i].BiosName, net[i].IpAddress);
        }

        // Creating objects using parameter constructor

        Computer computer1 = new Computer("Bios-Computer1", "192.168.1.1");
        Computer computer2 = new Computer("Bios-Computer2", "192.168.1.2");

        // Creating objects using default constructor

        Computer comp01 = new Computer();
        comp01.BiosName = "alfa";
        comp01.IpAddress = "10.0." + getNum() + "." + getNum();

        Console.WriteLine(comp01.BiosName + " - " + comp01.IpAddress);
        Console.WriteLine("We have {0} computers!!", Computer.getCompNum());

        // Show ShowInfo
        
        computer1.ShowInfo();
        computer2.ShowInfo();
        comp01.ShowInfo();
    }
}
