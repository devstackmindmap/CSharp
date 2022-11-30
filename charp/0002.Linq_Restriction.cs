using System.Collections.Generic;

public class Linq_Restriction
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
        List<Product> products = GetProductList();

        var soldOutProducts = from prod in products
                            where prod.UnitsInStock == 0
                            select prod;

        Console.WriteLine("Sold out products:");
        foreach (var product in soldOutProducts)
        {
            Console.WriteLine($"{product.ProductName} is sold out!");
        }

        // Filter elements on multiple properties
        products = GetProductList();

        var expensiveInStockProducts = from prod in products
                                    where prod.UnitsInStock > 0 && prod.UnitPrice > 3.00
                                    select prod;

        Console.WriteLine("In-stock products that cost more than 3.00:");
        foreach (var product in expensiveInStockProducts)
        {
            Console.WriteLine($"{product.ProductName} is in stock and costs more than 3.00.");
        }

        // Examine a sequence property of output elements
        List<Customer> customers = GetCustomerList();

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

    private static List<Product> GetProductList()
    {
        return new List<Product>{
            new Product { ProductName = "A", UnitsInStock = 0, UnitPrice = 3.1d },
            new Product { ProductName = "B", UnitsInStock = 1, UnitPrice = 3.0d},
            new Product { ProductName = "C", UnitsInStock = 1, UnitPrice = 3.1d},
            new Product { ProductName = "D", UnitsInStock = 0, UnitPrice = 3.0d}
        };
    }

    private static List<Customer> GetCustomerList()
    {
        return new List<Customer>{
            new Customer { Region = "WA", CustomerID = 1, CompanyName = "A Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "WA", CustomerID = 2, CompanyName = "B Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "KR", CustomerID = 3, CompanyName = "A Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "KR", CustomerID = 4, CompanyName = "B Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
        };
    }

    
}

class Product
{
    public string ProductName = "";
    public int UnitsInStock = 0;

    public double UnitPrice = 0d;
}

class Customer
{
    public string Region = "";
    public int CustomerID = 0;
    public string CompanyName = "";
    public List<Order> Orders = new List<Order>();
}

class Order
{
    public int OrderID;
    public string OrderDate = "1";
}
