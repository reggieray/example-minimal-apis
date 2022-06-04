using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    class TodoApplication : WebApplicationFactory<Program>
    {
        private readonly Action<IServiceCollection>? _configureDelegate;

        public TodoApplication(Action<IServiceCollection>? configureDelegate = null)
        {
            this._configureDelegate = configureDelegate;
        }

        protected override IHost CreateHost(IHostBuilder builder)
        {
            if (_configureDelegate is not null)
            {
                builder.ConfigureServices(_configureDelegate);
            }

            return base.CreateHost(builder);
        }
    }
}
