
// Language: C#
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SCBAlogger.Data;
using SCBAlogger.Model;
using System;
using System.Windows.Forms;

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


            

            // DefaultConnection
         
            string conn = configuration.GetConnectionString("DefaultConnection");

            var contextOptions = new DbContextOptionsBuilder<SCBAContext>().UseSqlServer(conn).Options;
            SCBAContext context = new SCBAContext(contextOptions);
            context.Database.EnsureCreated();



            Application.Run(new Main(context));
        }


        
    }
}