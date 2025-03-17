namespace containerApp.ship;

public class Ship(int speed, int maxContainerCount, int maxPayload)
{
    public List<Container> Containers { get; set; }
    public int Speed { get; set; }
    public int MaxContainerCount { get; set; }
    public int MaxPayload { get; set; }

    private double _actualPayload = 0;

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainerCount)
        {
            Console.WriteLine($"Ship is full (max number of containers): {MaxPayload}, " +
                              $"actual number of containers: {Containers.Count}");
        }
        else if (_actualPayload >= MaxPayload)
        {
            Console.WriteLine($"Ship is full (max payload): {MaxPayload}, " +
                              $"actual payload: {_actualPayload}");
        }
        else
        {
            _actualPayload += container.CargoWeight;
            _actualPayload += container.TareWeight;
            Containers.Add(container);
        }
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void UnloadContainer(Container container)
    {
        if (Containers.Count > 0)
        {
            Containers.Remove(container);
        }
        else
        {
            Console.WriteLine("Ship is empty");
        }
    }

    public void ReplaceContainerByNumber(string number, Container containerToReplace)
    {
        var container = Containers.Find(c => c.SerialNumber == number);
        UnloadContainer(container);
        LoadContainer(container);
    }

    public void TransferToAnotherShip(Container containerToTransfer, Ship shipToTransfer)
    {
        UnloadContainer(containerToTransfer);
        shipToTransfer.LoadContainer(containerToTransfer);
    }

    public override string ToString()
    {
        var info = $"Ship info: Speed: {Speed}," +
                   $" Max number of containers: {MaxContainerCount}, Max payload: {MaxPayload}" +
                   "Cargo info: ";
        foreach (var container in Containers)
        {
            info += container.ToString();
        }

        return info;
    }
}