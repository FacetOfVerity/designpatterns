using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRpcCountExample;
using gRpcFileLoadingExample;

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

            await RunCounterExample(channel);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        private static async Task RunCounterExample(GrpcChannel channel)
        {
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
        }
        
//        private static async Task RunFileLoadingExample(GrpcChannel channel)
//        {
//            var client = new Loader.
//            do
//            {
//                Console.Write("Press Enter");
//                try
//                {
//                    var response = await client.GetCountAsync(new Google.Protobuf.WellKnownTypes.Empty());
//                    Console.WriteLine($"Count: {response.Count}");
//                }
//                catch (Exception e)
//                {
//                    Console.WriteLine(e);
//                }
//
//                
//            } while (Console.ReadKey().Key == ConsoleKey.Enter);
//        }
    }
}