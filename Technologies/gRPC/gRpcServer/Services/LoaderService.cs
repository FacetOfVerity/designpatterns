using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRpcFileLoadingExample;

namespace gRpcServer.Services
{
    public class LoaderService : Loader.LoaderBase
    {
        public override async Task<ImageModel> GetImage(Empty request, ServerCallContext context)
        {
            string imageUrl =
                "https://pbs.twimg.com/media/DY-0BhFXcAAwqXZ.jpg";
            
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(imageUrl))
                {
                    var data = await response.Content.ReadAsByteArrayAsync();
                    var byteString = ByteString.CopyFrom(data);
                    var message = new ImageModel{Data = byteString};
                    
                    return message;
                }
            }

            
        }
    }
}