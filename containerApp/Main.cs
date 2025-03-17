using containerApp;
//using containerApp.view;
using containerApp.ship;

//Simulation of app operation (some methods)
// Engine engine = new Engine();
// engine.Run();

Console.WriteLine("CREATING A CONTAINER SHIP");
var ship = new Ship("uno", 1000, 4, 200);
Console.WriteLine(ship.ToString());


Console.WriteLine("\n\nCREATING A CONTAINER");
var containerL = new LiquidContainer(20.2, 30, 40, 100, true);
Console.WriteLine(containerL.ToString());


Console.WriteLine("\n\nLOADING CARGO INTO A CONTAINER");
//containerL.LoadWithCargo(200); //throws exception about overfilling
containerL.LoadWithCargo(30);
Console.WriteLine(containerL.ToString());


Console.WriteLine("\n\nLOADING CONTAINER ONTO A SHIP");
ship.LoadContainer(containerL);
ship.PrintCargoInfo();


Console.WriteLine("\n\nLOADING LIST OF CONTAINERS ONTO A SHIP");
var containerG = new GasContainer(20, 10, 30, 20, false, 100);
var containerR = new RefrigeratedContainer(10, 20, 30, 100, 5, "Fish");
ship.LoadContainers(new List<Container> { containerG, containerR });
ship.PrintCargoInfo();


Console.WriteLine("\n\nPRINT INFO ABOUT A CONTAINER");
Console.WriteLine(containerG.ToString());


Console.WriteLine("\n\nPRINT INFO ABOUT A SHIP AND ITS CARGO");
Console.WriteLine(ship.ToString());
ship.PrintCargoInfo();


Console.WriteLine("\n\nREMOVING CONTAINER FROM A SHIP");
ship.PrintCargoInfo();
ship.UnloadContainer(containerG.SerialNumber);
ship.PrintCargoInfo();


Console.WriteLine("\n\nUNLOADING A CONTAINER");
Console.WriteLine(containerL.ToString());
containerL.EmptyCargo();
Console.WriteLine(containerL.ToString());


Console.WriteLine("\n\nTRANSFERRING CONTAINER BETWEEN TWO SHIPS");
ship.PrintCargoInfo();
var ship2 = new Ship("dos", 2000, 3, 200);
ship.TransferToAnotherShip(containerL, ship2);
ship.PrintCargoInfo();
ship2.PrintCargoInfo();

Console.WriteLine("\n\nREPLACING A CONTAINER");
ship2.PrintCargoInfo();
var containerL2 = new LiquidContainer(100, 30, 40, 200, false);
ship2.ReplaceContainerByNumber(containerL.SerialNumber, containerL2);
ship2.PrintCargoInfo();