using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    class RoseBottle : Weapon
    {
        public override void DealDamage(IDamageRecepient target)
        {
            Console.WriteLine($"{target.Nickname} получает наживое ранение");
        }

        public RoseBottle(string weaponName) : base(weaponName)
        {
        }
    }
}
