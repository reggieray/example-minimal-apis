using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Examples.MinimalApi.Todo.FastEndpoints.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;

namespace Examples.MinimalApi.Todo.FastEndpoints.IntegrationTests
{
    class TodoApplication : WebApplicationFactory<Program>
    {
        private readonly Action<IServiceCollection>? _configureDelegate;

        public TodoApplication(
            Action<IServiceCollection>? configureDelegate = null)
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

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var db = services.FirstOrDefault(c => c.ServiceType == typeof(DbContextOptions<TodoDb>));

                if (db is not null)
                {
                    services.Remove(db);
                }

                var sqliteConnection = new SqliteConnection("Data Source=:memory:");
                sqliteConnection.Open();

                services.AddDbContext<TodoDb>(options =>
                {
                    options.UseSqlite(sqliteConnection);
                });
            });
        }
    }
}
