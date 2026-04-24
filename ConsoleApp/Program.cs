using ConsoleApp;

//funkcja wygenerowana na podstawie nagłówka funkcji
int Sum(float a, float b) //Tokenizacja: [Type: int] [Identifier: Sum] [Punctuation: (] [Type: float] [Identifier: a] [Punctuation: ,] [Type: float] [Identifier: b] [Punctuation: )]
{
    return (int)(a + b);
}

//funkcja wygenerowana na podstawie komentarza
//substract two float numbers and return an integer. use block body syntax
int Subtract(float a, float b)
{
    return (int)(a - b);
}


//multiply two numbers
float Multiply(float a, float b)
{
    return (a * b);
}

//pierwotnie wygenerowana funkcja Multiply została zmodyfikowana przez użytkownika
//co spwodowało, że model dostosował kolejny generowany kod (Divide) do zmian użytkownika
//kontenst "nauki" copilot jest ograniczony do bieżącej sesji - np. wyłączenie IDE powoduje utratę kontekstu

//divide two numbers
float Divide(float a, float b)
{
    if (b == 0)
    {
        throw new DivideByZeroException("Cannot divide by zero.");
    }
    return (a / b);
}

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