using System;

namespace Inheritance.Abstractions
{
    /// <summary>
    /// Супергерой
    /// </summary>
    public abstract class SuperHero : Person, IDamageSender
    {
        public SuperHero(string nickname) : base(nickname)
        {
        }

        /// <summary>
        /// Перемещение супергероя к указанной цели
        /// </summary>
        /// <param name="place">Пункт назначения</param>
        public virtual void Move(string place)
        {
            Console.WriteLine($"Иду-Иду-Иду. Пришел в {place}");
        }

        public override void AboutMe()
        {
            Console.WriteLine($"Друзья называю меня {Nickname}, и да, я супергерой.");
        }

        /// <summary>
        /// Нанесение урона противнику
        /// </summary>
        /// <param name="target">Цель</param>
        public virtual void DealDamage(IDamageRecepient target)
        {
            Console.WriteLine($"{target.Nickname} будет наказан!");
            target.TakeDamage(this);
            Console.WriteLine("Дело сделано, злодей наказан!");
        }
    }
}