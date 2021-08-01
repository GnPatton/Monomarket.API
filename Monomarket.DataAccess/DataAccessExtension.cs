using Microsoft.Extensions.DependencyInjection;
using Monomarket.Business.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monomarket.DataAccess
{
    public static class DataAccessExtension
    {
        public static IServiceCollection AddMonomarketRepositories(this IServiceCollection self)
        {
            self.AddScoped<IUnitOfWork, UnitOfWork>();

            return self;
        }
    }
}
