

public class ProductHelper
{
    public static List<Product> GetProductList()
    {
        return new List<Product>{
            new Product { ProductName = "A", UnitsInStock = 0, UnitPrice = 3.1d, Category = "Black"},
            new Product { ProductName = "B", UnitsInStock = 1, UnitPrice = 3.0d, Category = "Black"},
            new Product { ProductName = "C", UnitsInStock = 1, UnitPrice = 3.1d, Category = "White"},
            new Product { ProductName = "D", UnitsInStock = 0, UnitPrice = 3.0d, Category = "White"}
        };
    }

    public static List<Customer> GetCustomerList()
    {
        return new List<Customer>{
            new Customer { Region = "WA", CustomerID = 1, CompanyName = "A Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "WA", CustomerID = 2, CompanyName = "B Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "KR", CustomerID = 3, CompanyName = "A Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
            new Customer { Region = "KR", CustomerID = 4, CompanyName = "B Company", Orders = {new Order { OrderID = 1, OrderDate = "1"}}},
        };
    }
}

public class Product
{
    public string ProductName = "";
    public int UnitsInStock = 0;
    public double UnitPrice = 0d;
    public string Category = "";
}

public class Customer
{
    public string Region = "";
    public int CustomerID = 0;
    public string CompanyName = "";
    public List<Order> Orders = new List<Order>();
}

public class Order
{
    public int OrderID;
    public string OrderDate = "1";
}