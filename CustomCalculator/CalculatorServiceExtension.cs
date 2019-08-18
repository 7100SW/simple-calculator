using Microsoft.Extensions.DependencyInjection;

namespace CustomCalculator
{
    public static class CalculatorServiceExtension
    {
        public static IServiceCollection AddCalculator(this IServiceCollection services)
        {
            services.AddTransient<TokenMatcher>();
            services.AddTransient<ICommandParser, CommandParser>();
            services.AddTransient<ICalculator, Calculator>();

            return services;
        }
    }

}
