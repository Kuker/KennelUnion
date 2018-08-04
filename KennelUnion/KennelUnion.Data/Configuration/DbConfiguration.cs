using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace KennelUnion.Data.Configuration
{
    public interface IDbConfiguration
    {
        string ConnectionString { get; }
    }

    public class DbConfiguration : IDbConfiguration
    {
        private readonly IConfiguration _configuration;

        public DbConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionString => _configuration["ConnectionString"];
    }
}
