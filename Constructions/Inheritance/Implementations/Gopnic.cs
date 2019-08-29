using Inheritance.Abstractions;

namespace Inheritance.Implementations
{
    public class Gopnic : SuperVillain, IArmedHero
    {
        public Gopnic(string nickname) : base(nickname)
        {
            Weapon = new RoseBottle("Разбитая бутылка");
        }

        public Weapon Weapon { get; }

        public override void DealDamage(IDamageRecepient target)
        {
            Weapon.DealDamage(target);
        }
    }
}
