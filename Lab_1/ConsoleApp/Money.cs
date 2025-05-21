public class Money
{
    public int WholePart { get; set; }
    public int FractionalPart { get; set; }

    public Money(int wholePart, int fractionalPart)
    {
        WholePart = wholePart;
        FractionalPart = fractionalPart;
    }

    public void SetValues(int whole, int fractional)
    {
        WholePart = whole;
        FractionalPart = fractional;
    }

    public void DisplayAmount()
    {
        Console.WriteLine($"{WholePart}.{FractionalPart:D2} $");
    }
}
