using FluentValidation;

namespace SeedWork.Infrastructure.MassTransit
{
    public class RabbitMqEndpointOptions
    {
        public string Host { get; set; }

        public string VirtualHost { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ReceiveEndpoint { get; set; }

        /// <summary>
        /// Количество повторных попыток.
        /// </summary>
        public int RetryCount { get; set; }

        public void Validate()
        {
            var validator = new EndpointOptionsValidator();
            validator.ValidateAndThrow(this);
        }
    }

    public class EndpointOptionsValidator : AbstractValidator<RabbitMqEndpointOptions>
    {
        public EndpointOptionsValidator()
        {
            RuleFor(a => a.Host).NotEmpty();
            RuleFor(a => a.VirtualHost).NotEmpty();
            RuleFor(a => a.Username).NotEmpty();
            RuleFor(a => a.Password).NotEmpty();
            RuleFor(a => a.ReceiveEndpoint).NotEmpty();
            RuleFor(a => a.RetryCount).GreaterThanOrEqualTo(0);
        }
    }
}
