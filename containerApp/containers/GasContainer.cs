namespace containerApp;

public class GasContainer : Container, IHazardNotifier
{
    public int Pressure { get; set; }
    public bool IsHazardous { get; set; }

    public GasContainer(int height, int depth, int weight, int maxPayload, bool isHazardous, int pressure)
        : base(height, depth, weight, maxPayload)
    {
        IsHazardous = isHazardous;
        Pressure = pressure;
        SerialNumber = "KON-G-" + GenerateSerialNumber();
    }

    public override void EmptyCargo()
    {
        Console.WriteLine("Cargo emptied (gas)");
        CargoWeight *= 0.05;
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
}