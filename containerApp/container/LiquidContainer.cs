namespace containerApp;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(double height, double depth, double weight, double maxPayload, bool isHazardous)
        : base(height, depth, weight, maxPayload)
    {
        IsHazardous = isHazardous;
        SerialNumber = "KON-L-" + GenerateSerialNumber();
    }

    public override void EmptyCargo()
    {
        Console.WriteLine("Cargo emptied (liquid)");
        CargoWeight = 0;
    }

    public override void LoadWithCargo(int cargoWeight)
    {
        base.LoadWithCargo(cargoWeight);

        if (IsHazardous && cargoWeight > MaxPayload * 0.5)
        {
            SendNotification("Hazardous cargo - can be filled to 50% of capacity");
        }

        if (!IsHazardous && cargoWeight > MaxPayload * 0.9)
        {
            SendNotification("Not hazardous cargo - can be filled to 90% of capacity");
        }

        CargoWeight = cargoWeight;
    }

    public void SendNotification(string notification)
    {
        Console.WriteLine($"Notification for {SerialNumber}: {notification}");
    }

    public override string ToString()
    {
        return base.ToString() + $"IsHazardous: {IsHazardous}";
    }
}