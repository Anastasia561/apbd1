namespace containerApp;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; set; }
    public double Temperature { get; set; }

    private Dictionary<string, double> _productsToTemperatures = new Dictionary<string, double>
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18 },
        { "Fish", 2 },
        { "Meat", -15 },
        { "Ice cream", -18 },
        { "Frozen pizza", -30 },
        { "Cheese", 7.2 },
        { "Sausages", 5 },
        { "Butter", 20.5 },
        { "Eggs", 19 }
    };

    public RefrigeratedContainer(int height, int depth, int weight, int maxPayload,
        double temperature, string productType)
        : base(height, depth, weight, maxPayload)
    {
        ProductType = productType;
        if (temperature < _productsToTemperatures[ProductType])
        {
            Console.WriteLine($"Temperature for {ProductType} should be greater than" +
                              $" {_productsToTemperatures[ProductType]}");
            Temperature = _productsToTemperatures[ProductType];
        }
        else
        {
            Temperature = temperature;
        }

        SerialNumber = "KON-R-" + GenerateSerialNumber();
    }

    public override void EmptyCargo()
    {
        Console.WriteLine($"Cargo emptied ({ProductType})");
    }
}