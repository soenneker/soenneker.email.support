using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Email.Dispatcher.Registrars;
using Soenneker.Email.Support.Abstract;

namespace Soenneker.Email.Support.Registrars;

/// <summary>
/// A utility that allows for quick access to support email sending
/// </summary>
public static class EmailSupportUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IEmailSupportUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEmailSupportUtilAsSingleton(this IServiceCollection services)
    {
        services.AddEmailDispatcherAsSingleton().TryAddSingleton<IEmailSupportUtil, EmailSupportUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IEmailSupportUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddEmailSupportUtilAsScoped(this IServiceCollection services)
    {
        services.AddEmailDispatcherAsScoped().TryAddScoped<IEmailSupportUtil, EmailSupportUtil>();

        return services;
    }
}
