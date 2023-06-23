using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Fight
    {
        // Fields
        private Hero hero;
        private Monster monster;

        // Properties

        // Methods
        public void HeroTurn() // Damage Calculations for hero damage
        {
            int damage = hero.Strength + hero.Weapon.ItemPower - monster.Defence;
            monster.CurrentHealth -= damage;
            Console.WriteLine($"Hero attacks the {monster.Name} and deals {damage} damage!");
        }

        public void MonsterTurn() // Damage calculations for monster damage
        {
            int damage = monster.Strength - (hero.Defence + hero.Armor.ItemPower);
            hero.CurrentHealth -= damage;
            Console.WriteLine($"{monster.Name} attacks the hero and deals {damage} damage!");
        }

        // Win and lose condition statements based on hero hp
        public bool Win()
        {
            if (monster.CurrentHealth <= 0)
            {
                Console.WriteLine($"The hero defeats the {monster.Name}!");
                return true;
            }
            return false;
        }

        public bool Lose()
        {
            if (hero.CurrentHealth <= 0)
            {
                Console.WriteLine($"The hero is defeated by the {monster.Name}!");
                hero.CurrentHealth = hero.Health;
                return true;
            }
            return false;
        }

        // Constructor
        public Fight(Hero hero, Monster monster)
        {
            this.hero = hero;
            this.monster = monster;
        }
    }
}
