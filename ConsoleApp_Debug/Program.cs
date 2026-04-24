List<int> numbers = new();

foreach (var arg in args)
{
    if (int.TryParse(arg, out int number))
    {
        numbers.Add(number);
    }
}
int result = SumEvenNumbers(numbers);
Console.WriteLine($"Sum of even numbers: {result}");


int SumEvenNumbers(List<int> numbers)
{
    int sum = 0;

    foreach (var n in numbers)
    {
        if (n % 2 == 0)
        {
            sum += n;
        }
        // do nothing for odd numbers
    }

    return sum;
}

