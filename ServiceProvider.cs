using System;
using NUnit.Framework;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using OpenQA.Selenium;
using Serilog.Events;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace PetWithOleksii
{
    public class ServiceProvider : IDriverProvider
    {
        WebDriver webDriver;

        public static IServiceProvider Instance { get; } = InitServiceProvider();

        private static IServiceProvider InitServiceProvider()
        {
            IServiceCollection collection = new ServiceCollection();


            Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Debug()
                    .WriteTo.Console()
                    .CreateLogger();

            var filePath = Environment.GetEnvironmentVariable("TestRunSettings");
            filePath = string.IsNullOrWhiteSpace(filePath) ? "appsettings.json" : filePath;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var config = new ConfigurationBuilder()
                .AddJsonFile(filePath, false, true)
                .Build();
            var settings = new T();
            collection.AddSingleton(config).AddSingleton(settings);
            return collection.BuildServiceProvider();
        }
    }
}
