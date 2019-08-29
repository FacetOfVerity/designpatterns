using System;
using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    /// <summary>
    /// Орудие железного человека
    /// </summary>
    public class IronManWeapon : Weapon
    {
        public override void DealDamage(IDamageRecepient target)
        {
            Console.WriteLine($"Выстрел из {WeaponName} по {target.Nickname}");
        }

        public IronManWeapon(string weaponName) : base(weaponName)
        {
        }
    }
}