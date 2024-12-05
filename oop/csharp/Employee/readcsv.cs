using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class ReadCsv
{
    public static List<string[]> ReadCsvFile(string filePath)
    {
        List<string[]> rows = new List<string[]>();

        try
        {
            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Process each line and split by the comma to get individual values
            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                // Add the values to the list of rows
                rows.Add(values);
            }

            Console.WriteLine("CSV file read successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }

        return rows;
    }
}

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

public class Manager{
    public string Name{
        get;
        set;
    }
    public Manager(string name){
        Name = name;
    }

    public void Hire(string name, double income, string department, string month, int year, List<Employee> employees, List<Incomes> incomes){
        int newid = employees.Count +1;       //ask
        Employee newEmployee = new Employee (newid, name, department);

        employees.Add(newEmployee);
        Incomes newIncome = new Incomes (newid, month, year, income);
        incomes.Add(newIncome);

        Console.WriteLine($"Employee {newEmployee.Name} was hired successfully");

    }
}

class Program
{
    static StreamWriter log;
    //obtain employees from the csv
    static List<Employee> GetEmployee(string filePath)
    {
        List<Employee> employees = new List<Employee>();
        List<string[]> csvData = ReadCsv.ReadCsvFile(filePath);

        for (int i = 0; i < csvData.Count; i++)
        {
            string[] row = csvData[i];

            
            if (int.TryParse(row[0], out int id))
            {
                string name = row[1];
                string department = row[2];

                // Create an Employee object and add it to the list

                Employee employee = new Employee(id, name, department);
                employees.Add(employee);
            }
            else
            {
                Console.WriteLine($"Invalid ID format at row {i + 1}: {row[0]}");
            }
        }


        return employees;
    }

    static List<Incomes> GetIncome(string filePath){
        List<Incomes> incomesList = new List<Incomes>();
        List<string[]> csvData = ReadCsv.ReadCsvFile(filePath);

        for (int i=0; i<csvData.Count; i++){
            string[] row = csvData[i];

            if (int.TryParse(row[0], out int id)){
                string month = row[1];

                if (int.TryParse(row[2], out int year) && double.TryParse(row[3], out double incomeValue)){
                
                //Create an Income object and add it to the list

                Incomes income = new Incomes(id,month,year,incomeValue);
                incomesList.Add(income);
                } else{
                    Console.WriteLine($"Invalid data format at row {i+1}: Year or income is incorrect");
                }
            } else{
                Console.WriteLine($"Invalid ID format at row {i + 1}: {row[0]}");
            }
        }
        return incomesList;
    }


    //Method for show employees list ordered by salary
    static void ShowHiguestIncome(List<Employee> employees, List<Incomes> incomesList){

        //Make a combined list of employes and incomes
        var orderedList = employees.Join(
            incomesList,
            employee => employee.ID,        //with this employee=> we select the key element on what the jointlist will be based
            income => income.ID,
            (employee, income) => new{      //when the id of an employee is the same as the incomes id it creates a new list with the employees name and incomes income
                employee.Name,
                income.Income
            }
        ).OrderByDescending (data=> data.Income);

        foreach ( var data in orderedList ){
        Console.WriteLine($"Name: {data.Name}, Income: {data.Income}");
       }

    }

    static void ShowAverageIncomeByDepartment(List<Employee> employees, List<Incomes> incomesList){
        var orderedList2 = employees.Join(
            incomesList,
            employee => employee.ID,        //key = id
            income => income.ID,  //key = id
            (employee, income) => new{
                employee.Name,
                employee.Department,
                income.Income
            }
        );

        var averageIncomeByDepartment = orderedList2
            .GroupBy(data => data.Department) //this function groups elements of the given list by that key ( in this case the key is department)
            .Select (group => new{          // with select its created an object for each group with the name of the department
                Department = group.Key,
                AverageIncome = group.Average(data => data.Income) //function average calculates de average of something
            });

        foreach ( var data in averageIncomeByDepartment){
            Console.WriteLine($"Department: {data.Department}, Average Income: {data.AverageIncome}");
        }
    }


    static void Main(){

        log = new StreamWriter("log.csv",true);
        string csvFilePath1 = "emps.csv";
        string csvFilePath2 = "income.csv";

        // Obtain de list of employees

        List<Employee> employees = GetEmployee(csvFilePath1);
        List<Incomes> incomes = GetIncome(csvFilePath2);

        // Show the list of employees

        //foreach (Employee employee in employees){
       //     Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Department: {employee.Department}");
        //}

        
        //foreach (Incomes income in incomes){
        //    Console.WriteLine($"ID: {income.ID}, Month: {income.Month}, Year: {income.Year}, Income: {income.Income}");
       // }
       foreach(var income in incomes){
        foreach(var employee in employees){
            if(income.ID == employee.ID){
                Console.WriteLine($"ID: {employee.ID}, Name: {employee.Name}, Department:{employee.Department}, Month: {income.Month}, Year: {income.Year}, Income: {income.Income}");
                log.WriteLine($"{employee.Name},{employee.Department},{income.Month},{income.Year},{income.Income}");
            }
        }
       }
       ShowHiguestIncome(employees,incomes);
       ShowAverageIncomeByDepartment (employees,incomes);

        Manager juan = new Manager("Juan");
        juan.Hire("JohnSmith", 2600, "HR", "December", 2024, employees, incomes);
        
       log.Flush();
       log.Close();
    }
}
