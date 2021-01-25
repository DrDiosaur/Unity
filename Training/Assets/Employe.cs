using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Employe : MonoBehaviour
{
    public static string companyName = "GameDevHq";
    public string employeeName;

    public abstract void CalculateMonthSalary();
}


public class FullTime : Employe
{
    public int salary;
    
    public override void CalculateMonthSalary()
    {
        throw new System.NotImplementedException();
    }
}

public class PartTime : Employe
{
    public int hoursWorked;
    public int hourlyRate;
    
    public override void CalculateMonthSalary()
    {
        throw new System.NotImplementedException();
    }
}