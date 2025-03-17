using containerApp.exceptions;

namespace containerApp;

public abstract class Container(int height, int depth, int weight, int maxPayload)
{
    public double CargoWeight { get; set; }
    public double Height { get; set; }
    public double Depth { get; set; }
    public double TareWeight { get; set; }
    public string SerialNumber { get; set; }
    public int MaxPayload { get; set; }

    public abstract void EmptyCargo();

    public virtual void LoadWithCargo(int cargoWeight)
    {
        if (cargoWeight > maxPayload)
            throw new OverfillException("Weight of cargo to be larger than max payload");
    }

    protected static int GenerateSerialNumber()
    {
        var random = new Random();
        return random.Next();
    }
}