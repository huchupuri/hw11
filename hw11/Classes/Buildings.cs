using hw10.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11.Classes
{
    internal class Buildings
    {
        private Building[] buildings;

        public Buildings() 
        {
            buildings = new Building[10];
        }
        public Buildings(Building[] buildings)
        {
            this.buildings = buildings;
        }

        public Building this[int index]
        {
            get
            {
                if (index < 0 || index >= buildings.Length)
                    Console.WriteLine("недопустимое значение");
                return buildings[index];
            }
            set
            {
                if (index < 0 || index >= buildings.Length)
                    Console.WriteLine("недопустимое значени");
                buildings[index] = value;
            }
        }
    }
}
