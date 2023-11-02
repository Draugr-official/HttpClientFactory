using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace System.Net.Http.Tests
{
    public class Tests
    {
        [Fact]
        public static async void TestDefaultHttpClientFactory()
        {
            HttpClient httpClient = HttpClientFactory.CreateClient();
            Assert.NotNull(httpClient);

            HttpResponseMessage response = await httpClient.GetAsync("https://example.com/");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public static void TestNamedHttpClientFactory()
        {
            HttpClient testHttpClient = HttpClientFactory.CreateClient("test");
            int testHashCode = testHttpClient.GetHashCode();
            
            HttpClient testHttpClient2 = HttpClientFactory.CreateClient("test");
            int testHashCode2 = testHttpClient2.GetHashCode();

            Assert.Equal(testHashCode, testHashCode2);
        }
    }
}
