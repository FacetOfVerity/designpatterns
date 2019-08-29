using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    /// <summary>
    /// Железный человек
    /// </summary>
    public class IronMan : SuperHero, IArmedHero
    {
        public Weapon Weapon { get; }

        public override void DealDamage(IDamageRecepient target)
        {
            Console.WriteLine($"{target.Nickname} будет наказан!");
            Weapon.DealDamage(target);
            target.TakeDamage(this);
            Console.WriteLine("Дело сделано, злодей наказан!");
        }

        public IronMan(string nickname) : base(nickname)
        {
            Weapon = new IronManWeapon("Стреляющая плазмой перчатка");
        }
    }
}