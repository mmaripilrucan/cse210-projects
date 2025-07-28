using System;

class Program
{
    static void Main(string[] args)
    {
        
        Address usaAddress = new Address("898 Main St", "Las Vegas", "NV", "USA");
        Address internationalAddress = new Address("656 Oxford St", "London", "England", "UK");

        
        Customer customer1 = new Customer("Joseph Carroll", usaAddress);
        Customer customer2 = new Customer("Agnes Bird", internationalAddress);

        
        Product product1 = new Product("Laptop", "PLU000", 899.99, 1);
        Product product2 = new Product("Mouse", "PLU001", 9.99, 1);
        Product product3 = new Product("Keyboard", "PLU002", 39.99, 1);
        Product product4 = new Product("Monitor", "PLU003", 159.99, 1);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);
        order2.AddProduct(product2);

        
        Console.WriteLine("Order 1:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}");

        Console.WriteLine("\n---------------------------------\n");

        Console.WriteLine("Order 2:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}");
    }
}