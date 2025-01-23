using hw10.Enums;
using hw11.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    [DeveloperOrganization("Маркелов Михаил", "Re")]
    [DeveloperOrganization("Не Михаил")]
    [DeveloperOrganization()]
    public class Building
    {
        private static uint lastBuildingId = 0;
        public uint buildingId { get; set; }
        public double? height { get; set; }
        public uint? floors { get; set; }
        public uint? apartments { get; set; }
        public uint? entrances { get; set; }


        internal Building(double? height, uint? floors, uint? apartments, uint? entrances)
        {
            buildingId = GenerateBuildingId();
            this.height = height;
            this.floors = floors;
            this.apartments = apartments;
            this.entrances = entrances;
        }

        /// <summary>
        /// генерация номера здания
        /// </summary>
        private uint GenerateBuildingId()
        {
            lastBuildingId++;
            return lastBuildingId;
        }

        /// <summary>
        /// генерирование id
        /// </summary>
        public uint GetBuildingId()
        {
            return buildingId;
        }



        /// <summary>
        /// расчет высоты
        /// </summary>
        public double? GetFloorHeight()
        {
            return height / floors;
        }

        /// <summary>
        /// кол-во этажей в подъезде
        /// </summary>
        public uint? GetApartmentsPerEntrance()
        {
            return apartments / entrances;
        }
        public uint? GetApartmentsPerFloor()
        {
            return apartments / (floors * entrances);
        }


        /// <summary>
        /// вывод информации
        /// </summary>
        public void PrintInfo()
        {
            Console.WriteLine($"Здание ID: {buildingId}");
            Console.WriteLine($"Высота: {height} м");
            Console.WriteLine($"Этажность: {floors}");
            Console.WriteLine($"Количество квартир: {apartments}");
            Console.WriteLine($"Количество подъездов: {entrances}");
            Console.WriteLine($"Высота этажа: {GetFloorHeight():F2} м");
            Console.WriteLine($"Квартир на подъезд: {GetApartmentsPerEntrance()}");
            Console.WriteLine($"Квартир на этаже: {GetApartmentsPerFloor()}\n");
        }
        public override string ToString()
        {
            string buildingInfo =
                $"Здание ID: {buildingId}\n" +
                $"Высота: {height} м\n" +
                $"Этажность: {floors}\n" +
                $"Количество квартир: {apartments}\n" +
                $"Количество подъездов: {entrances}\n" +
                $"Высота этажа: {GetFloorHeight():F2} м\n" +
                $"Квартир на подъезд: {GetApartmentsPerEntrance()}\n" +
                $"Квартир на этаже: {GetApartmentsPerFloor()}\n";
            return buildingInfo;
        }
    }
}
