using ConsoleApp;

// Przykłady użycia MathOperations
Console.WriteLine(MathOperations.Sum(1.2f, 3.4f));
Console.WriteLine(MathOperations.Subtract(5f, 2f));
Console.WriteLine(MathOperations.Multiply(2f, 3.5f));
Console.WriteLine(MathOperations.Divide(10f, 2f));

Point3D CreatePoint(float[] tab)
{
    if (tab.Length < 3)
    {
        throw new ArgumentException("Array must contain at least three elements.");
    }
    return new Point3D(tab[0], tab[1], tab.Length > 2 ? tab[2] : 0);
}

//funkcja do wygenerowania 10 produktów
List<Product> GenerateProducts()
{
    var products = new List<Product>();
    for (int i = 1; i <= 10; i++)
    {
        products.Add(new Product
        {
            Name = $"Product {i}",
            Price = i * 10,
            Description = $"Description for Product {i}",
            Category = $"Category {((i - 1) / 5) + 1}",
            CategoryName = $"Category Name {((i - 1) / 5) + 1}"
        });
    }
    return products;
}