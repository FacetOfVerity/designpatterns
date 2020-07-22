using System;
using AbstractFactory.Factories;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var victorianFactory = new VictorianFurnitureFactory();
            var victorianChair = victorianFactory.CreateChair();
            var victorianCoffeTable = victorianFactory.CreateCoffeTable();
            var victorianSofa = victorianFactory.CreateSofa();
            var victorianSet = new Set(victorianChair, victorianCoffeTable, victorianSofa);
            Console.WriteLine(victorianSet);

            var modernFactory = new ModernFurnitureFactory();
            var modernChair = modernFactory.CreateChair();
            var modernCoffeTable = modernFactory.CreateCoffeTable();
            var modernSofa = modernFactory.CreateSofa();
            var modernSet = new Set(modernChair, modernCoffeTable, modernSofa);
            Console.WriteLine(modernSet);

//            var set = Set
//                .CreateSetWithChairAndCoffeTable(victorianChair, victorianCoffeTable)
//                .ToString();

            Console.ReadKey();
        }
    }
}
