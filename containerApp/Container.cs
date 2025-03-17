using containerApp.exceptions;

namespace containerApp;

public abstract class Container(int cargoWeight, int height, int depth, int weight, int maxPayload)
{
    public int CargoWeight { get; set; }
    public int Height { get; set; }
    public int Depth { get; set; }
    public int Weight { get; set; }
    public string SerialNumber { get; set; }
    public int MaxPayload { get; set; }

    public abstract void EmptyCargo();

    public virtual void LoadWithCargo(int cargoWeight)
    {
        if (cargoWeight > maxPayload)
            throw new OverfillException("Weight of cargo to be larger than max payload");
    }

    private int GenerteSerialNumber()
    {
        Random random = new Random();
        return random.Next();
    }
}