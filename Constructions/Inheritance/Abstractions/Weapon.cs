namespace Inheritance.Abstractions
{
    /// <summary>
    /// Орудие
    /// </summary>
    public abstract class Weapon
    {
        public string WeaponName { get; set; }

        public abstract void DealDamage(IDamageRecepient target);

        protected Weapon(string weaponName)
        {
            WeaponName = weaponName;
        }
    }
}
