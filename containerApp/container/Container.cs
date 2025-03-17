using containerApp.exceptions;

namespace containerApp;

public abstract class Container(double height, double depth, double weight, double maxPayload)
{
    public double CargoWeight { get; set; }
    public double Height { get; set; } = height;
    public double Depth { get; set; } = depth;
    public double TareWeight { get; set; } = weight;
    public string SerialNumber { get; set; }
    public double MaxPayload { get; set; } = maxPayload;

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

    public override string ToString()
    {
        return $"Container info: Serial number: {SerialNumber}, Cargo weight: {CargoWeight} kg, " +
               $"Height: {Height} cm, Depth: {Depth} cm, Tare weight: {TareWeight} kg";
    }
}