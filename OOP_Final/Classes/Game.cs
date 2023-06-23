using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public static class Game
    {
        // Fields
        private static Hero _hero;
        // Hard coded monsters
        private static readonly HashSet<Monster> _monsters = new HashSet<Monster>
        {
            new Monster("Goblin", 10, 5, 35),
            new Monster("Orc", 15, 8, 50),
            new Monster("Dragon", 25, 12, 100),
            new Monster("Skeleton", 8, 4, 40),
            new Monster("Troll", 20, 10, 70)
        };
        private static HashSet<Weapon> _weaponInventory = new HashSet<Weapon>
        {
            new Weapon("Sword", 10),
            new Weapon("Axe", 15),
            new Weapon("Bow", 8)
        };
        private static readonly HashSet<Armor> _armorInventory = new HashSet<Armor>
        {
            new Armor("Shield", 5),
            new Armor("Plate Mail", 10),
            new Armor("Leather Vest", 3)
        };


        // Properties

        // Methods
        public static void NewHero(string newHeroName) // Creates a new hero and sets it to current hero
        {
            Weapon startingWeapon = new Weapon("Starting Sword", 5);
            Armor startingArmor = new Armor("Starting Shield", 5);
            Hero hero = new Hero(newHeroName);
            hero.EquipArmor(startingArmor);
            hero.EquipWeapon(startingWeapon);
            _hero = hero;
            Console.WriteLine($"New hero {newHeroName} has been created.");
        }
        // New Weapon, Armor, and Monster methods aren't used as I have hard coded them for testing code
        public static void NewMonster(string newMonsterName, int str, int def, int hp) // Creates a new monster and adds it to a collection
        {
            Monster newMonster = new Monster(newMonsterName, str, def, hp);
            _monsters.Add(newMonster);
            Console.WriteLine($"New monster {newMonsterName} has been created.");
        }

        public static void NewWeapon(string itemName, int itemPower) // Creates a new weapon and adds it to the weapon inventory
        {
            Weapon newWeapon = new Weapon(itemName, itemPower);
            _weaponInventory.Add(newWeapon);
            Console.WriteLine($"New Weapon '{itemName}' has been created");
        }

        public static void NewArmor(string itemName, int itemPower) // Creates a new armor and adds it to the armor inventory
        {
            Armor newArmor = new Armor(itemName, itemPower);
            _armorInventory.Add(newArmor);
            Console.WriteLine($"New Armor '{itemName}' has been created");
        }

        public static void ChangeEquippedWeapon()
        {
            Console.WriteLine("Available Weapons:");
            // Display the available weapons for the player to choose
            int index = 1;
            foreach (Weapon weapon in _weaponInventory)
            {
                Console.WriteLine($"{index}. {weapon.Name} (+{weapon.ItemPower})");
                index++;
            }

            // Prompts to change the item
            Console.Write("Enter the number corresponding to the weapon you want to equip: ");
            string choice = Console.ReadLine();
            // ChatGPT to find a solution to changing weapon
            if (int.TryParse(choice, out int weaponIndex) && weaponIndex >= 1 && weaponIndex <= _weaponInventory.Count)
            {
                Weapon selectedWeapon = _weaponInventory.ElementAt(weaponIndex - 1);
                _hero.EquipWeapon(selectedWeapon);
            }
            else
            {
                Console.WriteLine("Invalid choice. Weapon not equipped.");
            }
        }

        public static void ChangeEquippedArmor()
        {
            Console.WriteLine("Available Armours:");
            // Works the same as the changeWeapon Method
            int index = 1;
            foreach (var armor in _armorInventory)
            {
                Console.WriteLine($"{index}. {armor.Name} (+{armor.ItemPower})");
                index++;
            }

            Console.Write("Enter the number corresponding to the armour you want to equip: ");
            string choice = Console.ReadLine();
            if (int.TryParse(choice, out int armorIndex) && armorIndex >= 1 && armorIndex <= _armorInventory.Count)
            {
                Armor selectedArmor = _armorInventory.ElementAt(armorIndex - 1);
                _hero.EquipArmor(selectedArmor);
            }
            else
            {
                Console.WriteLine("Invalid choice. Armour not equipped.");
            }
        }

        public static void StartFight()
        {
            // Randomly select a monster from the available monsters
            //https://learn.microsoft.com/en-us/dotnet/api/system.random?view=net-7.0
            Random random = new Random();
            int monsterIndex = random.Next(_monsters.Count); 
            Monster monster = _monsters.ElementAt(monsterIndex);

            Console.WriteLine($"A wild {monster.Name} attacks!");

            // Keeps the fight going until win or lose condition is hit
            Fight fight = new Fight(_hero, monster);
            bool fightInProgress = true;

            while (fightInProgress)
            {
                fight.HeroTurn();
                if (fight.Win())
                {
                    break;
                }

                fight.MonsterTurn();
                if (fight.Lose())
                {
                    break;
                }
            }
        }

        public static void Start()
        {
            while (true)
            {
                // Displays Menu
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Display Statistics");
                Console.WriteLine("2. Display Inventory");
                Console.WriteLine("3. Change Equipped Weapon");
                Console.WriteLine("4. Change Equipped Armor");
                Console.WriteLine("5. Fight");
                Console.WriteLine("6. Exit Game");

                // Prompts User input
                Console.Write("What would you like to do: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                // Same as playlist lab from Algorithms course
                switch (choice)
                {
                    case "1":
                        _hero.GetStats();
                        break;
                    case "2":
                        _hero.GetInventory();
                        break;
                    case "3":
                        ChangeEquippedWeapon();
                        break;
                    case "4":
                        ChangeEquippedArmor();
                        break;
                    case "5":
                        StartFight();
                        break;
                    case "6":
                        Console.WriteLine("Exiting the game.");
                        return;
                    default:
                        // Default error if none of the switch cases are triggered
                        Console.WriteLine("Invalid choice. Please, try again.");
                        break;
                }
            }
        }
    }
}
