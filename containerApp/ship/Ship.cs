namespace containerApp.ship;

public class Ship(string name, double speed, int maxContainerCount, double maxPayload)
{
    public List<Container> Containers = new List<Container>();
    public string Name { get; set; } = name;
    public double Speed { get; set; } = speed;
    public int MaxContainerCount { get; set; } = maxContainerCount;
    public double MaxPayload { get; set; } = maxPayload;

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

    public void UnloadContainer(string number)
    {
        if (Containers.Count > 0)
        {
            var container = Containers.Find(c => c.SerialNumber == number);
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
        UnloadContainer(number);
        LoadContainer(containerToReplace);
    }

    public void TransferToAnotherShip(Container containerToTransfer, Ship shipToTransfer)
    {
        UnloadContainer(containerToTransfer.SerialNumber);
        shipToTransfer.LoadContainer(containerToTransfer);
    }

    public override string ToString()
    {
        return $"Ship info: Name: {Name}, Speed: {Speed}," +
               $" Max number of containers: {MaxContainerCount}, Max payload: {MaxPayload}";
    }

    public void PrintCargoInfo()
    {
        if (Containers.Count > 0)
        {
            Console.WriteLine($"Cargo info of ship '{Name}': ");
            foreach (var container in Containers)
            {
                Console.WriteLine(container.ToString());
            }
        }
    }
}