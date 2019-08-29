namespace Inheritance.Abstractions
{
    /// <summary>
    /// Интерфейс логики получения урона
    /// </summary>
    public interface IDamageRecepient : IPerson
    {
        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="sender">Источник урона</param>
        void TakeDamage(IDamageSender sender);
    }
}
