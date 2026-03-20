
// Language: C#
using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using SCBAlogger.Model;
using SCBAlogger.Data;

namespace SCBAlogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Enables visual styles for controls (modern look)
            Application.EnableVisualStyles();

            // Ensures text rendering is compatible with older versions
            Application.SetCompatibleTextRenderingDefault(false);

            // Build configuration from appsettings.json, per-machine overrides, and environment variables
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.MachineName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Setup DI
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, configuration);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Create and run the main form
            //Application.Run(new Main());
            Application.Run(
                Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService<Main>(serviceProvider));
        }


        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // Register IConfiguration so services can consume configuration values
            services.AddSingleton<IConfiguration>(configuration);

            // Resolve connection string priority:
            // 1. appsettings.json / appsettings.{Machine}.json -> "ConnectionStrings:DefaultConnection"
            // 2. Environment variable "SCBAlogger_CONNECTION"
            // 3. Fallback to local SQLExpress instance
            string connFromConfig = configuration.GetConnectionString("DefaultConnection");
            string connFromEnv = Environment.GetEnvironmentVariable("SCBAlogger_CONNECTION");
            string conn = connFromConfig
                          ?? connFromEnv
                          ?? @"Data Source=.\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";

            services.AddDbContext<SCBAContext>(options =>
                options.UseSqlServer(conn));

            services.AddTransient<Main>();
            services.AddTransient<Config>();
            services.AddTransient<ProgressDialog>();


        }
    }
}