using System.Collections.Generic;

public class ProjectionOperators
{
    public static void Run()
    {
        // Select clause
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var numsPlusOne = from n in numbers
                        select n + 1;

        Console.WriteLine("Numbers + 1:");
        foreach (var i in numsPlusOne)
        {
            Console.WriteLine(i);
        }

        // Select a single property
        List<Product> products = ProductHelper.GetProductList();

        var productNames = from p in products
                   select p.ProductName;

        Console.WriteLine("Product Names:");
        foreach (var productName in productNames)
        {
            Console.WriteLine(productName);
        }

        // Transform with select
        string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

        var textNums = from n in numbers
                    select strings[n];

        Console.WriteLine("Number strings:");
        foreach (var s in textNums)
        {
            Console.WriteLine(s);
        }
    }
}
