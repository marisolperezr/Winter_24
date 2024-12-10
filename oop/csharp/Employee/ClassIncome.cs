using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using library_Manager;
using library_Readcsv;
using library_Employee;

namespace library_Incomes{

public class Incomes
{
    public int ID { 
        get; 
        set; 
    }
    public string Month { 
        get; 
        set; 
    }
    public int Year { 
        get; 
        set; 
    }
    public double Income { 
        get; 
        set; 
    }

    public Incomes(int id, string month, int year, double income)
    {
        ID = id;
        Month = month;
        Year = year;
        Income = income;
    }
}
}
