﻿using CpmPedido.Interface;
using CpmPedidos.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CpmPedidos.API
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection serviceProvider)
        {
            RepositoryDependence(serviceProvider);
        }

        private static void RepositoryDependence(IServiceCollection serviceProvider)
        {
            serviceProvider.AddScoped<ICidadeRepository, CidadeRepository>();
        }
    }
}