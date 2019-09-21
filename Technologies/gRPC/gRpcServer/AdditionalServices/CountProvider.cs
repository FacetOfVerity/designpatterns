namespace gRpcServer.AdditionalServices
{
    public class CountProvider
    {
        public int Count { get; private set; }

        public CountProvider()
        {
            Count = 0;
        }

        public void IncrementCount()
        {
            Count++;
        }
    }
}