using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDatabase : MonoBehaviour
{
    public Customer John;

    public Customer Max;

    public Customer Elise;
    // Start is called before the first frame update
    void Start()
    {
        John = new Customer("John", "Weak", 25, 'M', "Killer");
        Elise = NewCustomer("Elise", "Weak", 24, 'F', "Wife");
        Max = NewCustomer("Max", "Weak", 14, 'M', "schooler");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Customer NewCustomer(string Fname, string Lname, int age, char gen, string occ)
    {
        var customer = new Customer(Fname, Lname, age, gen, occ);
        return customer;
    }
}
