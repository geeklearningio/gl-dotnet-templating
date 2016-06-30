namespace GeekLearning.Templating
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class GeekLearningMustacheTemplatingExtensions
    {
        public static IServiceCollection AddMustache(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<ITemplateProvider, Mustache.MustacheSharpTemplateProvider>());
            return services;
        }
    }
}
