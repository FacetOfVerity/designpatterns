using System;
using System.Collections.Generic;
using System.Text;
using AbstractFactory.Items;
using AbstractFactory.Items.Victorian;

namespace AbstractFactory.Factories
{
    public class VictorianFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new VictorianChair();
        }

        public ICoffeTable CreateCoffeTable()
        {
            return new VictorianCoffeTable();
        }

        public ISofa CreateSofa()
        {
            return new VictorianSofa();
        }
    }
}
