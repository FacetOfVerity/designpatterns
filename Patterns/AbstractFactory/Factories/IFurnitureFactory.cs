using AbstractFactory.Items;

namespace AbstractFactory.Factories
{
    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ICoffeTable CreateCoffeTable();
        ISofa CreateSofa();
    }
}
