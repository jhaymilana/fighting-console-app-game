// Final

using Classes;

Console.WriteLine("Welcome to Realm of Legends");
Console.WriteLine();

try 
{ 
    Console.WriteLine("To start please enter a name:");

    Console.Write("> ");
    string newName = Console.ReadLine();

    Game.NewHero(newName);

}
catch (ArgumentException)
{
    throw new ArgumentException("Name cannot be empty.");
}

Game.Start();