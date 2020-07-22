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

        public static Set CreateSetWithChairAndCoffeTable(IChair chair, ICoffeTable coffeTable)
        {
            return new Set(chair, coffeTable);
        }

        public Set(IChair chair, ICoffeTable coffeTable, ISofa sofa) : this(chair, coffeTable)
        {
            Sofa = sofa;
        }

        private Set(IChair chair, ICoffeTable coffeTable)
        {
            Chair = chair;
            CoffeTable = coffeTable;
        }

        public override string ToString()
        {
            return $"Кресло {Chair.GetType().Name}, Столик {CoffeTable.GetType().Name}, Диван {Sofa.GetType().Name}";
        }
    }
}
