using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw10.Classes
{
    internal class Building
    {
        private static uint lastBuildingId = 0;
        private uint buildingId { get; set; }
        private double? height { get; set; }
        private uint? floors { get; set; }
        private uint? apartments { get; set; }
        private uint? entrances { get; set; }


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
        /// установка значений
        /// </summary>
        public void SetID(uint id) => buildingId = id;
        public void SetHeight(uint newHeight) => height = newHeight;
        public void SetFloors(uint newFloors) => floors = newFloors;
        public void SetApartments(uint newApartments) => height = newApartments;
        public void SetEntrances(uint newEntrances) => entrances = newEntrances;

        /// <summary>
        /// генерирование id
        /// </summary>
        public uint GetBuildingId()
        {
            return buildingId;
        }

        /// <summary>
        /// вывод высоты
        /// </summary>
        public double? GetHeight()
        {
            return height;
        }

        /// <summary>
        /// вывод кол-во этажей
        /// </summary>
        public uint? GetFloors()
        {
            return floors;
        }

        /// <summary>
        /// вывод кол-во квартир
        /// </summary>
        public uint? GetApartments()
        {
            return apartments;
        }

        /// <summary>
        /// вывод кол-во подъездов
        /// </summary>
        public uint? GetEntrances()
        {
            return entrances;
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
    }
}
