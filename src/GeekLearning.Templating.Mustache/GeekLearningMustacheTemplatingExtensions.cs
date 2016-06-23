using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public static class GeekLearningMustacheTemplatingExtensions
    {
        public static IServiceCollection AddMustache(this IServiceCollection services)
        {
            services.TryAddTransient<ITemplateProvider, Mustache.MustacheSharpTemplateProvider>();
            return services;
        }
    }
}
