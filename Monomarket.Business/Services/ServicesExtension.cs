using Microsoft.Extensions.DependencyInjection;
using Monomarket.Business.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monomarket.Business.Services
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddMonoServices(this IServiceCollection self)
        {
            self.AddTransient<IUserService, UserService>();

            return self;
        }
    }
}
