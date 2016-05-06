using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GeekLearning.Templating
{
    public static class GeekLearningTemplatingExtensions
    {
        public static IServiceCollection AddTemplating(this IServiceCollection services)
        {
            services.TryAddTransient<ITemplateLoaderFactory, Implementation.TemplateLoaderFactory>();
            services.TryAddTransient<ITemplateProvider, Handlebars.HandlebarsTemplateProvider>();

            return services;
        }
    }
}
