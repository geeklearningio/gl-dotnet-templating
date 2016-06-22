using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using GeekLearning.Storage;

namespace GeekLearning.Templating.Handlebars
{
    public class MustacheSharpTemplateProvider : ITemplateProvider
    {
        public MustacheSharpTemplateProvider()
        {
            this.MimeTypes = new HashSet<string>() { "text/x-mustache-template" };
            this.Extensions = new HashSet<string>() { ".hbs" };
        }

        public ISet<string> MimeTypes { get; }
        public ISet<string> Extensions { get; }

        public ITemplate Compile(string templateContent)
        {
            return new HandlebarsTemplate(templateContent);
        }
    }
}
