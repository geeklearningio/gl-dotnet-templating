namespace GeekLearning.Templating
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class GeekLearningTemplatingExtensions
    {
        public static IServiceCollection AddTemplating(this IServiceCollection services)
        {
            services.TryAddTransient<ITemplateLoaderFactory, Internal.TemplateLoaderFactory>();
            return services;
        }
    }
}
