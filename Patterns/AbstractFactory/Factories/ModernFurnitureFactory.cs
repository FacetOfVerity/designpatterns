using AbstractFactory.Items;
using AbstractFactory.Items.Modern;

namespace AbstractFactory.Factories
{
    public class ModernFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ModernChair();
        }

        public ICoffeTable CreateCoffeTable()
        {
            return new ModernCoffeTable();
        }

        public ISofa CreateSofa()
        {
            return new ModernSofa();
        }
    }
}
