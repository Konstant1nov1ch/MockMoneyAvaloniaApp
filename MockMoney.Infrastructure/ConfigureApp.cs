using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MockMoney.Abstractions;
using MockMoney.Abstractions.HttpClients;
using MockMoney.Commands.Pipelines;
using MockMoney.Infrastructure.HttpClients;


namespace MockMoney.Infrastructure;

public static class ConfigureApp
{
    public static IServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();

        //Configuration
        IConfiguration configuration;
#if DESKTOP
        configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:false)
            .Build();
        serviceCollection.AddSingleton<IConfiguration>(configuration);
#else
        
#endif
        

        //Logging
        serviceCollection.AddLogging(builder => builder.AddConsole());

        //MediatR
        serviceCollection.AddMediatR(configuration => { configuration.RegisterServicesFromAssembly(typeof(LoggingBehavior<,>).Assembly); });
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //vALIDATOR
        serviceCollection.AddValidatorsFromAssembly(typeof(LoggingBehavior<,>).Assembly);
        ConfigureServices(serviceCollection);
        return serviceCollection.BuildServiceProvider();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        //HttpClients
        services.AddHttpClient<IMockMoneyHttpClient,MockMoneyHttpClient>();
    }
}