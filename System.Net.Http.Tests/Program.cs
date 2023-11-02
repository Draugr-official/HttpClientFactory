using System.Net.Http;

namespace System.Net.Http.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tests.TestDefaultHttpClientFactory();
            Tests.TestNamedHttpClientFactory();

            Console.WriteLine("Tests complete");
        }
    }
}