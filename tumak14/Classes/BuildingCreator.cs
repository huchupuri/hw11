using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class BuildingCreator
    {
        private static Hashtable buildings = new Hashtable();
        private BuildingCreator() { }
        public static Building CreateBuild(double? height, uint? floors, uint? apartments, uint? entrances)
        {
            Building building = new Building(height, floors, apartments, entrances);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild(double? height, uint? floors)
        {
            Building building = new Building(height, floors, null, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild(double? height, uint? floors, uint? apartments)
        {
            Building building = new Building(height, floors, apartments, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }
        public static Building CreateBuild()
        {
            Building building = new Building(null, null, null, null);
            buildings.Add(building.GetBuildingId(), building);
            return building;
        }

        /// <summary>
        /// удаление здания по id
        /// </summary>
        public static void DeleteBuild(uint id)
        {
            if (buildings.ContainsKey(id))
            {
                buildings.Remove(id);
                Console.WriteLine($"здание {id} удалено ");
            }
            else Console.WriteLine($"здания {id} не существует");
        }
    }
}
