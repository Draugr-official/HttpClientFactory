namespace System.Net.Http
{
    /// <summary>
    /// HttpClientFactory to implement resilient HTTP requests
    /// </summary>
    public class HttpClientFactory
    {
        static Dictionary<string, HttpClient> NamedHttpClients = new Dictionary<string, HttpClient>();

        /// <summary>
        /// Settings for configuring the creation of HttpClients
        /// </summary>
        public static HttpClientFactorySettings Settings = new HttpClientFactorySettings()
        {
            PooledConnectionLifetime = 15
        };

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        static HttpClient httpClient = new HttpClient(new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(Settings.PooledConnectionLifetime)
        });

        /// <summary>
        /// Gets a long-lived HttpClient
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreateClient()
        {
            return httpClient;
        }

        /// <summary>
        /// Creates and registers a named HttpClient. If a client with given name already exists, this will be returned instead
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HttpClient CreateClient(string name)
        {
            if(NamedHttpClients.ContainsKey(name))
            {
                return NamedHttpClients[name];
            }
            
            HttpClient httpClient = new HttpClient(new SocketsHttpHandler
            {
                PooledConnectionLifetime = TimeSpan.FromMinutes(Settings.PooledConnectionLifetime)
            });

            NamedHttpClients.Add(name, httpClient);

            return httpClient;
        }

        /// <summary>
        /// Creates and registers a named HttpClient with a SocketsHttpHandler. If a client with given name already exists, this will be returned instead
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static HttpClient CreateClient(string name, SocketsHttpHandler socketsHttphandler)
        {
            if (NamedHttpClients.ContainsKey(name))
            {
                return NamedHttpClients[name];
            }

            if (socketsHttphandler.PooledConnectionLifetime == Timeout.InfiniteTimeSpan)
            {
                socketsHttphandler.PooledConnectionLifetime = TimeSpan.FromMinutes(Settings.PooledConnectionLifetime);
            }

            HttpClient httpClient = new HttpClient(socketsHttphandler);

            NamedHttpClients.Add(name, httpClient);

            return httpClient;
        }
    }

    /// <summary>
    /// Settings for configuring the creation of HttpClients
    /// </summary>
    public class HttpClientFactorySettings
    {
        /// <summary>
        /// Gets or sets the life time of a pooled connection in minutes
        /// </summary>
        public int PooledConnectionLifetime { get; set; } = 15;
    }
}