// See https://aka.ms/new-console-template for more information


using ContosoPizzaContext context = new ContosoPizzaContext();

// 입력
//Product veggieSpecial = new Product()
//{
//    Name = "Veggie Spoecial Pizza",
//    Price = 9.99M
//};
//context.Add(veggieSpecial);

//Product deluxeMeat = new Product()
//{
//    Name = "Deluxe Meat Pizza",
//    Price = 12.99M
//};

//context.Add(deluxeMeat);
//context.SaveChanges();


// 수정
//var veggieSpecial = context.Products
//    .Where(p => p.Name == "Veggie Special Pizza")
//    .FirstOrDefault();

//if (veggieSpecial is Product)
//{
//    veggieSpecial.Price = 10.99M;
//}

//context.SaveChanges();

// 출력
var products = from product in context.Products
               where product.Price > 10.00M
               orderby product.Name
               select product;

foreach (var product in products)
{
    Console.WriteLine(product.Name);
    Console.WriteLine(product.Price.ToString());
}



// 제거
//var veggieSpecial = context.Products
//    .Where(p => p.Name == "Veggie Special Pizza")
//    .FirstOrDefault();

//if (veggieSpecial is Product)
//{
//    context.Remove(veggieSpecial);
//}
//context.SaveChanges();