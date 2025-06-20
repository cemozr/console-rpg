using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRpg.Inventory
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public Item (string name, string description,int price)
        {
            Id = Guid.NewGuid ();
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
