using System;
using Inheritance.Implementations;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            var superman = new Superman("SuperMan");
            var vader = new DarthVader("DarthVader");
            superman.DealDamage(vader);
            var gopnic = new Gopnic("Vasya");
            //gopnic.DealDamage(superman); Superman не реализует интерфейс получения урона
            gopnic.DealDamage(vader);
            
            Console.ReadKey();
        }
    }
}
