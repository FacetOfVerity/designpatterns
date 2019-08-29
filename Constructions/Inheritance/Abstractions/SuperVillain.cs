using System;

namespace Inheritance.Abstractions
{
    /// <summary>
    /// Суперзлодей
    /// </summary>
    public abstract class SuperVillain : Person, IDamageRecepient, IDamageSender
    {
        public SuperVillain(string nickname) : base(nickname)
        {
        }

        public override void AboutMe()
        {
            Console.WriteLine($"Если кратко, то меня зовут {Nickname} и очень плохой.");
        }

        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="sender">Источник урона</param>
        public virtual void TakeDamage(IDamageSender sender)
        {
            Console.WriteLine($"{sender.Nickname} жестко наказывает {Nickname}-а. {Nickname} плачет.");
        }

        //Для разнообразия не будем делать метод виртуальным и делать реализацию по умолчанию
        public abstract void DealDamage(IDamageRecepient target);
    }}