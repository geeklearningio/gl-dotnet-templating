namespace GeekLearning.Templating
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class GeekLearningHandlebarsTemplatingExtensions
    {
        public static IServiceCollection AddHandlebars(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<ITemplateProvider, Handlebars.HandlebarsTemplateProvider>());
            return services;
        }
    }
}
