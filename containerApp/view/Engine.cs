using containerApp.ship;

namespace containerApp.view;

public class Engine
{
    private List<Ship> _ships = new List<Ship>();
    private List<Container> _containers = new List<Container>();

    public void Run()
    {
        while (true)
        {
            var options = "\nPossible options:\n1.Create a container ship";
            if (_ships.Count > 0)
            {
                options += "\n2.Remove a container ship";
                options += "\n3.Create a container";
                Console.WriteLine("\n\nList of container ships: ");

                foreach (var ship in _ships)
                {
                    Console.WriteLine(ship);
                    if (ship.Containers.Count > 0)
                    {
                        options += "\n5.Remove container from a ship";
                        Console.WriteLine("\nList of containers for ship: ");
                        foreach (var container in ship.Containers)
                        {
                            Console.WriteLine(container);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"List of containers for ship: None");
                    }
                }
            }
            else
            {
                Console.WriteLine("List of container ships: None");
            }

            if (_containers.Count > 0)
            {
                options += "\n4.Add a container to a ship";
                options += "\n6.Delete unassigned container";
                Console.WriteLine("List of not assigned containers: ");
                foreach (var container in _containers)
                {
                    Console.WriteLine(container);
                }
            }

            Console.WriteLine(options);
            var input = int.Parse(Console.ReadLine());
            ProcessInput(input);
        }
    }

    private void ProcessInput(int input)
    {
        switch (input)
        {
            case 1: CreateContainerShip(); break;
            case 2: RemoveContainerShip(); break;
            case 3: CreateContainer(); break;
            case 4: AddContainerToShip(); break;
            case 5: UnloadContainer(); break;
            case 6: DeleteContainer(); break;
            default: Console.WriteLine("Invalid input"); break;
        }
    }

    private void AddContainerToShip()
    {
        Console.WriteLine("Adding a container to ship: ");
        Console.WriteLine("Enter name of a ship to load container onto: ");
        var ship = _ships.Find(s => s.Name == Console.ReadLine());
        Console.WriteLine("Enter container number: ");
        var container = _containers.Find(s => s.SerialNumber == Console.ReadLine());
        ship.LoadContainer(container);
        _containers.Remove(container);
    }

    private void DeleteContainer()
    {
        Console.WriteLine("Deleting unassigned container");
        Console.Write("enter number of a container to be deleted: ");
        _containers.RemoveAll(c => c.SerialNumber == Console.ReadLine());
    }

    private void UnloadContainer()
    {
        Console.WriteLine("Unloading container");
        Console.Write("Enter name of ship: ");
        var ship = _ships.Find(s => s.Name == Console.ReadLine());
        Console.Write("Enter number of container: ");
        ship.UnloadContainer(Console.ReadLine());
    }

    private void RemoveContainerShip()
    {
        Console.WriteLine("Removing a container ship");
        Console.WriteLine("Enter name of a ship to be removed: ");
        var ship = _ships.Find(s => s.Name == Console.ReadLine());
        _ships.Remove(ship);
    }

    private void CreateContainerShip()
    {
        Console.WriteLine("Creating container ship");
        Console.WriteLine("Enter name: ");
        var name = Console.ReadLine();
        Console.Write("Enter speed: ");
        var speed = double.Parse(Console.ReadLine());
        Console.Write("Enter max number of containers allowed: ");
        var maxContainers = int.Parse(Console.ReadLine());
        Console.Write("Enter max payload allowed: ");
        var maxPayload = double.Parse(Console.ReadLine());

        _ships.Add(new Ship(name, speed, maxContainers, maxPayload));
    }

    private void CreateContainer()
    {
        Console.WriteLine("Creating container");
        Console.Write("Select type: [L]-liquid, [G]-Gas, [R]-Refrigerated");
        var type = Console.ReadLine();
        switch (type)
        {
            case "L": CreateContainerL(); break;
            case "G": CreateContainerG(); break;
            case "R": CreateContainerR(); break;
        }
    }

    private void CreateContainerL()
    {
        Console.WriteLine("Creating liquid container");
        Console.Write("Enter height: ");
        var height = double.Parse(Console.ReadLine());
        Console.Write("Enter depth: ");
        var depth = double.Parse(Console.ReadLine());
        Console.Write("Enter weight: ");
        var weight = double.Parse(Console.ReadLine());
        Console.Write("Enter max payload: ");
        var maxPayload = double.Parse(Console.ReadLine());
        Console.Write("Enter [y]es/[n]o if is hazardouse: ");
        var isHazardouse = Console.ReadLine().ToLower().Equals("y");

        _containers.Add(new LiquidContainer(height, depth, weight, maxPayload, isHazardouse));
    }

    private void CreateContainerG()
    {
        Console.WriteLine("Creating gas container");
        Console.Write("Enter height: ");
        var height = double.Parse(Console.ReadLine());
        Console.Write("Enter depth: ");
        var depth = double.Parse(Console.ReadLine());
        Console.Write("Enter weight: ");
        var weight = double.Parse(Console.ReadLine());
        Console.Write("Enter max payload: ");
        var maxPayload = double.Parse(Console.ReadLine());
        Console.Write("Enter [y]es/[n]o if is hazardouse: ");
        var isHazardouse = Console.ReadLine().ToLower().Equals("y");
        Console.Write("Enter pressure:");
        var pressure = int.Parse(Console.ReadLine());

        _containers.Add(new GasContainer(height, depth, weight, maxPayload, isHazardouse, pressure));
    }

    private void CreateContainerR()
    {
        Console.WriteLine("Creating refrigerated container");
        Console.Write("Enter height: ");
        var height = double.Parse(Console.ReadLine());
        Console.Write("Enter depth: ");
        var depth = double.Parse(Console.ReadLine());
        Console.Write("Enter weight: ");
        var weight = double.Parse(Console.ReadLine());
        Console.Write("Enter max payload: ");
        var maxPayload = double.Parse(Console.ReadLine());
        Console.Write("Enter temperature: ");
        var temperature = double.Parse(Console.ReadLine());
        Console.Write("Enter product type: ");
        var productType = Console.ReadLine();

        _containers.Add(new RefrigeratedContainer(height, depth, weight, maxPayload,
            temperature, productType));
    }
}