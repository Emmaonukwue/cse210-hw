using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // First order
        Address address1 = new Address("123 Maple St", "Salt Lake City", "UT", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Book", "B100", 10.99, 2));
        order1.AddProduct(new Product("Pen", "P200", 1.50, 5));

        Console.WriteLine("Order 1 Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 Total Price: ${order1.GetTotalCost():F2}\n");

        // Second order
        Address address2 = new Address("456 Pine Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "N300", 4.75, 3));
        order2.AddProduct(new Product("Stapler", "S400", 7.25, 1));

        Console.WriteLine("Order 2 Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 Total Price: ${order2.GetTotalCost():F2}");
    }
}
