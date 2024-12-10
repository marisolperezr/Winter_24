using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using library_Manager;
using library_Incomes;
using library_Readcsv;



namespace library_Employee{

public class Employee
{
    public int ID { 
        get; 
        set; 
        }
    public string Name { get; set; }
    public string Department { get; set; }

    public Employee(int id, string name, string department)
    {
        ID = id;
        Name = name;
        Department = department;
    }
}
}