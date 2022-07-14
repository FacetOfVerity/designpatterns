using MassTransit;

namespace SeedWork.Infrastructure.MassTransit
{
    /// <summary>
    /// Атрибут говорящий о специальном предназначении консьюмеров.
    /// Данные консьюмеры не будут подключаться автоматически к внутреней шине сообщений
    /// с помощью метода <see cref="RegistrationExtensions.AddConsumers(MassTransit.IRegistrationConfigurator,System.Reflection.Assembly[])"/>
    /// </summary>
    public class DisableConsumerAutoRegistrationAttribute : Attribute
    {
        /// <summary>
        /// Тип консьюмера (на основе этого параметра будет производиться фильтрация).
        /// </summary>
        public string ConsumerType { get; }

        /// <summary>
        /// Атрибут говорящий о специальном предназначении консьюмеров.
        /// </summary>
        /// <param name="consumerType"> Тип консьюмера (на основе этого параметра будет производиться фильтрация). </param>
        public DisableConsumerAutoRegistrationAttribute(string consumerType)
        {
            ConsumerType = consumerType;
        }
    }
}
