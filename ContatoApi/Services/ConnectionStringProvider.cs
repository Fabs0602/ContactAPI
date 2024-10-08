using Microsoft.Extensions.Configuration;

namespace ContatoApi.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }
    }
}