using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Customer
{
    public string FirstName;
    public string LastName;
    public int Age;
    public char Gender;
    public string Occupation;

    public Customer(string firstName, string lastName, int age, char gender, string occupation)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Gender = gender;
        this.Occupation = occupation;
    }
}
