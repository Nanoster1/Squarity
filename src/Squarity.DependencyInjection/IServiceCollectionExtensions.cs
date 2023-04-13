using Microsoft.Extensions.DependencyInjection;
using Squarity.DependencyInjection.Interfaces;
using Squarity.DependencyInjection.Services;

namespace Squarity.DependencyInjection;

public static class IServiceCollectionExtensions
{
    /// <summary>
    /// Зарегистрировать в контейнер сервисов <see cref="DefaultFigureCalculator" />
    /// </summary>
    public static IServiceCollection AddDefaultFigureCalculator(this IServiceCollection services)
    {
        return services.AddScoped<IFigureCalculator, DefaultFigureCalculator>();
    }

    /// <summary>
    /// Зарегистрировать в контейнер сервисов <see cref="DefaultFormulaCalculator" />
    /// </summary>
    public static IServiceCollection AddDefaultFormulaCalculator(this IServiceCollection services)
    {
        return services.AddScoped<IFormulaCalculator, DefaultFormulaCalculator>();
    }
}
