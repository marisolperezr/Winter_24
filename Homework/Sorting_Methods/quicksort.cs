using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {

        DateTime start;
        TimeSpan timeItTook;
        start = DateTime.Now;

        // Asking the user to insert the list values separated by comas

        Console.WriteLine("Insert the list's values separating them with comas , :");
        string input = Console.ReadLine();

        // Convert the entry into a list of numbers

        List<int> unsortedList = new List<int>();
        try
        {
            foreach (var item in input.Split(','))
            {
                unsortedList.Add(int.Parse(item.Trim()));
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Please check to only introduce numbers separated by comas.");
            return;
        }

        // Order the list using quicksort

        List<int> sortedList = QuickSort(unsortedList);

        // Show the sorted list

        Console.WriteLine("Sorted list:");
        Console.WriteLine(string.Join(", ", sortedList));

         // Calculate period of time

        timeItTook = DateTime.Now - start;
        
        Console.WriteLine(timeItTook);
    }

    static List<int> QuickSort(List<int> list)
    {
        if (list.Count <= 1)
            return list; // A list with only one element is already sorted

        // Select the pivot 

        int pivot = list[list.Count / 2];
        
        // Divide the list into three parts 

        List<int> less = new List<int>();
        List<int> equal = new List<int>();
        List<int> greater = new List<int>();

        foreach (var item in list)
        {
            if (item < pivot)
                less.Add(item);
            else if (item == pivot)
                equal.Add(item);
            else
                greater.Add(item);
        }

        // Combine the sorted lists

        List<int> result = new List<int>();
        result.AddRange(QuickSort(less));
        result.AddRange(equal);
        result.AddRange(QuickSort(greater));

        return result;
    }
}
