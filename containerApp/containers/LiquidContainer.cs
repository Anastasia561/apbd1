namespace containerApp;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; set; }

    public LiquidContainer(int height, int depth, int weight, int maxPayload, bool isHazardous)
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
            SendNotification("Hazardous - can be filled to 50% of capacity");
        }

        if (!IsHazardous && cargoWeight > MaxPayload * 0.9)
        {
            SendNotification("Not hazardous - can be filled to 90% of capacity");
        }

        CargoWeight = cargoWeight;
    }

    public void SendNotification(string notification)
    {
        Console.WriteLine($"Notification for {SerialNumber}: {notification}");
    }
}