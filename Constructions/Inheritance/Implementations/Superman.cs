using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    public class Superman : SuperHero
    {
        public override void Move(string place)
        {
            Console.WriteLine("Одел плащ, поднял правую руку вверх и полетел. " +
                              $"Прилетел в {place}");
        }

        public Superman(string nickname) : base(nickname)
        {
        }
    }
}
