using System.Collections.Generic;
using System.Linq;

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

        // Select anonymous types or tuples
        string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };

        var upperLowerWords = from w in words
                            select new { Upper = w.ToUpper(), Lower = w.ToLower() };

        foreach (var ul in upperLowerWords)
        {
            Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
        }

        var upperLowerWords2 = from w in words
                            select ( Upper: w.ToUpper(), Lower: w.ToLower() );

        foreach (var ul in upperLowerWords2)
        {
            Console.WriteLine($"Uppercase: {ul.Upper}, Lowercase: {ul.Lower}");
        }

        // Select anonymous types or tuples (test)
        var wordLengths = from w in words
        select new { Length = w.Length };

        foreach (var wl in wordLengths)
        {
            Console.WriteLine($"Length : {wl.Length} ");
        }

        // Use select to create new types
        var digitOddEvens = from n in numbers
                            select new { Digit = strings[n], Even = (n % 2 == 0) };

        foreach (var d in digitOddEvens)
        {
            Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.");
        }

        var digitOddEvens2 = from n in numbers
                    select (Digit: strings[n], Even: (n % 2 == 0));

        foreach (var d in digitOddEvens2)
        {
            Console.WriteLine($"The digit {d.Digit} is {(d.Even ? "even" : "odd")}.");
        }

        // Select a subset of properties
        var productInfos = from p in products
                   select (p.ProductName, p.Category, Price: p.UnitPrice);

        Console.WriteLine("Product Info:");
        foreach (var productInfo in productInfos)
        {
            Console.WriteLine($"{productInfo.ProductName} is in the category {productInfo.Category} and costs {productInfo.Price} per unit.");
        }

        // Select with index of item
        var numsInPlace = numbers.Select((num, index) => (Num: num, InPlace: (num == index)));
        Console.WriteLine("Number: In-place?");
        foreach (var n in numsInPlace)
        {
            Console.WriteLine($"{n.Num}: {n.InPlace}");
        }

        // Select combined with where
        var lowNums = from n in numbers
                        where n < 5
                        select strings[n];
        Console.WriteLine("Numbers < 5:");
        foreach (var num in lowNums)
        {
            Console.WriteLine(num);
        }
    }
}
