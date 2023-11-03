using System.Diagnostics;
using System.Net.Http;

namespace System.Net.Http.Tests
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Tests.TestDefaultHttpClientFactory();
            //Tests.TestNamedHttpClientFactory();

            //Console.WriteLine("Tests complete");

            double timeProxy = 0;
            double timeDefault = 0;
            
            HttpClient httpClient = HttpClientFactory.CreateClient("YO cuh", new SocketsHttpHandler
            {
                Proxy = new WebProxy
                {
                    Address = new Uri($"http://45.155.68.129:8133"),
                    BypassProxyOnLocal = false,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential("yewhpidk", "53jg3w7ld844")
                },
            });
            HttpClient httpClient2 = HttpClientFactory.CreateClient(">.<");

            Console.WriteLine("Running test proxy");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            for(int i = 0; i < 10; i++)
            {
                httpClient.GetAsync("https://example.com/").GetAwaiter().GetResult();
            }

            sw.Stop();
            timeProxy = sw.ElapsedMilliseconds;

            Console.WriteLine("Running test normal");
            sw.Restart();

            for (int i = 0; i < 10; i++)
            {
                httpClient2.GetAsync("https://example.com/").GetAwaiter().GetResult();
            }

            sw.Stop();
            timeDefault = sw.ElapsedMilliseconds;
            
            Console.WriteLine($"Proxy is {timeProxy / timeDefault} slower than no proxy");

            Console.ReadLine();
        }
    }
}