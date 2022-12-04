using System.Collections.Generic;

public class LinqRestriction
{
    public static void Run()
    {
        // LINQ query structure
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var lowNums = from num in numbers
                    where num < 5
                    select num;

        Console.WriteLine("Numbers < 5:");
        foreach (var x in lowNums)
        {
            Console.WriteLine(x);
        }

        // Filter elements on a property
        List<Product> products = ProductHelper.GetProductList();

        var soldOutProducts = from prod in products
                            where prod.UnitsInStock == 0
                            select prod;

        Console.WriteLine("Sold out products:");
        foreach (var product in soldOutProducts)
        {
            Console.WriteLine($"{product.ProductName} is sold out!");
        }

        // Filter elements on multiple properties
        products = ProductHelper.GetProductList();

        var expensiveInStockProducts = from prod in products
                                    where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00
                                    select prod;

        Console.WriteLine("In-stock products that cost more than 3.00:");
        foreach (var product in expensiveInStockProducts)
        {
            Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00.");
        }

        // Examine a sequence property of output elements
        List<Customer> customers = ProductHelper.GetCustomerList();

        var waCustomers = from cust in customers
                        where cust.Region == "WA"
                        select cust;

        Console.WriteLine("Customers from Washington and their orders:");
        foreach (var customer in waCustomers)
        {
            Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
            foreach (var order in customer.Orders)
            {
                Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
            }
        }

        // Filter elements based on position
        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var shortDigits = digits.Where((digit, index) => digit.Length < index);

        Console.WriteLine("Short digits:");
        foreach (var d in shortDigits)
        {
            Console.WriteLine($"The word {d} is shorter than its value.");
        }
    }    
}


