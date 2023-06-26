// Final

using Classes;

// Game Start Up text
Console.WriteLine("Welcome to Realm of Legends");
Console.WriteLine();

// Prompts user name and creates new hero
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

Game.Start(); // Main Menu