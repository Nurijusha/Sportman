using Microsoft.Extensions.DependencyInjection;
using Sportsman.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sportsman
{
    public static class LogicServiceRegistrator
    {
        public static IServiceCollection RegisterLogicServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ISportsmanService, SportsmanService>()
                .AddTransient<ITeamService, TeamService>();

            return serviceCollection;
        }
    }
}
