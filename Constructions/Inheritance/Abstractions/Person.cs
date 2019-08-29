namespace Inheritance.Abstractions
{
    /// <summary>
    /// Персона
    /// </summary>
    public abstract class Person : IPerson
    {
        /// <summary>
        /// Прозвище
        /// </summary>
        public string Nickname { get; }

        /// <summary>
        /// Рассказать о себе
        /// </summary>
        public abstract void AboutMe();

        protected Person(string nickname)
        {
            Nickname = nickname;
        }
    }
}