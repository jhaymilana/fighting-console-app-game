using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Hero
    {
        // Fields
        private string _heroName;
        private int _baseStrength = 15;
        private int _baseDefence = 10;
        private int _baseHealth = 25;
        private int _currentHealth;
        private Weapon _equippedWeapon;
        private Armor _equippedArmor;

        // Properties
        public string HeroName { get { return _heroName; } }
        public int Strength { get { return _baseStrength; } }
        public int Defence { get { return _baseDefence; } }
        public int Health { get { return _baseHealth; } }
        public int CurrentHealth
        {
            get { return _currentHealth; }
            set { _currentHealth = Math.Min(Math.Max(value, 0), _baseHealth); }
        }
        public Weapon Weapon { get { return _equippedWeapon; } }
        public Armor Armor { get { return _equippedArmor; } }


        // Methods
        public void GetStats() // Returns Hero Name and Base Stats (+ Item Power)
        {
            Console.WriteLine($"{HeroName} Stats:");
            Console.WriteLine($"HP: {Health}");
            Console.WriteLine($"Strength: {Strength} (+{Weapon.ItemPower})");
            Console.WriteLine($"Defence: {Defence} (+{ Armor.ItemPower})");
        }

        public void GetInventory() // Returns Hero's current equipped items
        {
            Console.WriteLine($"{HeroName} is currently equipped with:");
            Console.WriteLine($"Weapon: {Weapon.Name} (+{Weapon.ItemPower})");
            Console.WriteLine($"Armor: {Armor.Name} (+{Armor.ItemPower})");
        }
        // Equip methods not implemented (not working - currently using change item methods found in Game class)
        public void EquipWeapon(Weapon itemEquip) // Equips a new weapon item
        {
            _equippedWeapon = itemEquip;
            Console.WriteLine($"{HeroName} has equipped the weapon '{itemEquip.Name}' that has {itemEquip.ItemPower} strength.");
        }

        public void EquipArmor(Armor itemEquip) // Equips a new armor item
        {
            _equippedArmor = itemEquip;
            Console.WriteLine($"{HeroName} has equipped the armor '{itemEquip.Name}' that has {itemEquip.ItemPower} defence.");
        }

        // Constructor

        public Hero(string name)
        {
            _heroName = name;
        }
    }
}
