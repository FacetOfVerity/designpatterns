using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRpcCountExample;
using gRpcServer.AdditionalServices;
using Microsoft.Extensions.Logging;

namespace gRpcServer.Services
{
    public class CounterService : Counter.CounterBase
    {
        private readonly CountProvider _countProvider;
        private readonly ILogger<CounterService> _logger;

        public CounterService(CountProvider countProvider, ILogger<CounterService> logger)
        {
            _countProvider = countProvider;
            _logger = logger;
        }

        public override Task<CountReply> GetCount(Empty request, ServerCallContext context)
        {
            _logger.LogInformation("call");
            _countProvider.IncrementCount();
            
            return Task.FromResult(new CountReply{Count = _countProvider.Count});
        }
    }
}