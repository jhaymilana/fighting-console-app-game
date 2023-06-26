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
        private Hero _hero;
        private Monster _monster;

        // Properties

        // Methods
        public void HeroTurn() // Damage Calculations for hero damage
        {
            int damage = _hero.Strength + _hero.Weapon.ItemPower - _monster.Defence;
            _monster.CurrentHealth -= damage;
            Console.WriteLine($"Hero attacks the {_monster.Name} and deals {damage} damage!");
        }

        public void MonsterTurn() // Damage calculations for monster damage
        {
            int damage = _monster.Strength - (_hero.Defence + _hero.Armor.ItemPower);
            _hero.CurrentHealth -= damage;
            Console.WriteLine($"{_monster.Name} attacks the hero and deals {damage} damage!");
        }

        // Win and lose condition statements based on hero hp
        public bool Win()
        {
            if (_monster.CurrentHealth <= 0)
            {
                Console.WriteLine($"The hero defeats the {_monster.Name}!");
                return true;
            }
            return false;
        }

        public bool Lose()
        {
            if (_hero.CurrentHealth <= 0)
            {
                Console.WriteLine($"The hero is defeated by the {_monster.Name}!");
                _hero.CurrentHealth = _hero.Health;
                return true;
            }
            return false;
        }

        // Constructor
        public Fight(Hero hero, Monster monster)
        {
            _hero = hero;
            _monster = monster;
        }
    }
}