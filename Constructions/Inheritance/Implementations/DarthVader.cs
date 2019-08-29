using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    public class DarthVader: SuperVillain
    {
        public DarthVader(string nickname) : base(nickname)
        {
        }

        public override void TakeDamage(IDamageSender hero)
        {
            Console.WriteLine($"{hero.Nickname} бьёт по шлему");
            Console.WriteLine("Pshhh...");
        }

        public override void DealDamage(IDamageRecepient target)
        {
            Console.WriteLine("Взяу-зззь");
            target.TakeDamage(this);
        }
    }
}
