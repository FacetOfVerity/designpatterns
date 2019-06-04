using AbstractFactory.Items;

namespace AbstractFactory
{
    /// <summary>
    /// Набор элементов интерьера
    /// </summary>
    public class Set
    {
        public IChair Chair { get; set; }

        public ICoffeTable CoffeTable { get; set; }

        public ISofa Sofa { get; set; }

        public Set(IChair chair, ICoffeTable coffeTable, ISofa sofa)
        {
            Chair = chair;
            CoffeTable = coffeTable;
            Sofa = sofa;
        }

        public override string ToString()
        {
            return $"Кресло {Chair.GetType().Name}, Столик {CoffeTable.GetType().Name}, Диван {Sofa.GetType().Name}";
        }
    }
}
