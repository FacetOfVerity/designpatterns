using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRpcCountExample;

namespace gRpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // This switch must be set before creating the GrpcChannel/HttpClient.
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var client = new Counter.CounterClient(channel);
            do
            {
                Console.Write("Press Enter");
                try
                {
                    var response = await client.GetCountAsync(new Google.Protobuf.WellKnownTypes.Empty());
                    Console.WriteLine($"Count: {response.Count}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}