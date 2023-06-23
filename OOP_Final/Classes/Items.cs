using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Items
    {
        // Fields
        private string _name;
        private int _itemPower;

        // Properties
        public string Name { get { return _name; } }
        public int ItemPower { get { return _itemPower; } }

        // Methods

        // Constructor
        public Items(string name, int itemPower)
        {
            _name = name;
            _itemPower = itemPower;
        }
    }
}
