using System;
using System.Collections.Generic;
using System.IO;

public class Event
{
    public string Name { 
        get; 
        set; 
    }
    public DateTime Date { 
        get; 
        set; 
    }

    public Event(string name, DateTime date){
        Name = name;
        Date = date;
    }

    public virtual void GetInfo(){
        Console.WriteLine($"Event: {Name}, Date: {Date.ToString("yyyy-MM-dd")}");
    }
}

public class PaidEvent : Event{
    public decimal Price { 
        get; 
        set; 
    }

    public PaidEvent(string name, DateTime date, decimal price) : base(name, date) {
        Price = price;
    }

    public override void GetInfo(){
        Console.WriteLine($"Paid Event: {Name}, Date: {Date.ToString("yyyy-MM-dd")}, Price: ${Price}");
    }
}

public class Program {
    public static void Main(){
        List<Event> events = new List<Event>{
            new Event("Conference", new DateTime(2025, 2, 10)),
            new Event("Workshop", new DateTime(2025, 3, 5)),
            new Event("Dancing Contests", new DateTime(2025, 6, 5)),
            new Event ("Singing Contest", new DateTime(2025, 9, 12)),
            new PaidEvent("Public Cinema", new DateTime(2025, 4, 20), 30),
            new PaidEvent("Concert", new DateTime(2025, 2, 15), 50),
            new PaidEvent("Football Championship", new DateTime(2025, 8, 21), 10),
            new PaidEvent ("Chess Championship", new DateTime(2025, 7, 30), 15)
        };

        //Call the methods here

        Display_all_events(events);
        How_many_events(events);
    }

    // This methods display all the events and save the information shown in a log text file
    public static void Display_all_events(List<Event> events) {
        using (StreamWriter writer = new StreamWriter("log.txt", append: true)) {
            foreach (var e in events){
                e.GetInfo();
                writer.WriteLine($"Event: {e.Name}, Date: {e.Date.ToString("yyyy-MM-dd")}");
            }
        }
    }

    // This method uses a counter to calculate how many events are there in each month
    public static void How_many_events(List<Event> events) {
        var monthlyEventCount = new Dictionary<int, int>(); // Month is the key and number of events 

        foreach (var e in events){
            int month = e.Date.Month;
            if (!monthlyEventCount.ContainsKey(month)){
                monthlyEventCount[month] = 0;
            }
            monthlyEventCount[month]++;
        }

        foreach (var month in monthlyEventCount){
            Console.WriteLine($"Month {month.Key}: {month.Value} events");
        }
    }
}

