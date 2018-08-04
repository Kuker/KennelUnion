using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KennelUnion.Data.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KennelUnion.Data.DI
{
    public static class DatabaseServices
    {
        public static IServiceCollection RegisterDbDependencies(this IServiceCollection services)
        {
            services.AddTransient<IDbConfiguration, DbConfiguration>();

            return services;
        }
    }
}
