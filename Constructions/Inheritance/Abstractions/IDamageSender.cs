namespace Inheritance.Abstractions
{
    /// <summary>
    /// Интерфейс логики нанесения урона
    /// </summary>
    public interface IDamageSender : IPerson
    {
        /// <summary>
        /// Нанесение урона противнику
        /// </summary>
        /// <param name="target">Цель</param>
        void DealDamage(IDamageRecepient target);
    }
}
