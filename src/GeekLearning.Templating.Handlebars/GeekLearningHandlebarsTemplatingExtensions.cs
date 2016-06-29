using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public static class GeekLearningHandlebarsTemplatingExtensions
    {
        public static IServiceCollection AddHandlebars(this IServiceCollection services)
        {
            services.TryAddEnumerable(ServiceDescriptor.Transient<ITemplateProvider, Handlebars.HandlebarsTemplateProvider>());
            return services;
        }
    }
}
