using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    public class Spiderman : SuperHero
    {
        public override void Move(string place)
        {
            Console.WriteLine($"Заправился паутиной, и стреляя ей с двух рук постепенно допрыгал до {place}.");
        }

        public Spiderman(string nickname) : base(nickname)
        {
        }
    }
}
