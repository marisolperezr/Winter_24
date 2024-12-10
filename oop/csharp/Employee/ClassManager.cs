using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using library_Incomes;
using library_Readcsv;
using library_Employee;




namespace library_Manager{

public class Manager
{
    public string Name { get; set; }

    public Manager(string name)
    {
        Name = name;
    }

    public void Hire(string name, double income, string department, string month, int year, List<Employee> employees, List<Incomes> incomes)
    {
        int newid = employees.Count + 1;  // Ask
        Employee newEmployee = new Employee(newid, name, department);

        employees.Add(newEmployee);
        Incomes newIncome = new Incomes(newid, month, year, income);
        incomes.Add(newIncome);

        Console.WriteLine($"Employee {newEmployee.Name} was hired successfully");
    }
}
}