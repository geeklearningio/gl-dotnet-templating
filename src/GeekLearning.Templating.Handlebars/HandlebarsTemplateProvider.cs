using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using GeekLearning.Storage;
using HandlebarsDotNet;
using System.IO;

namespace GeekLearning.Templating.Handlebars
{
    public class HandlebarsTemplateProvider : ITemplateProvider
    {
        public HandlebarsTemplateProvider()
        {
            this.MimeTypes = new HashSet<string>() { "text/x-handlebars-template" };
            this.Extensions = new HashSet<string>() { ".hbs" };
        }

        public ISet<string> MimeTypes { get; }
        public ISet<string> Extensions { get; }

        public ITemplate Compile(string templateContent)
        {
            return new HandlebarsTemplate(templateContent);
        }

        public ITemplateProviderScope CreateScope()
        {
            return new Scope();
        }

        private class Scope : ITemplateProviderScope
        {
            private IHandlebars handlebars;

            public Scope()
            {
                this.handlebars = HandlebarsDotNet.Handlebars.Create();
            }

            public ITemplate Compile(string templateContent)
            {
                return new HandlebarsTemplate(handlebars, templateContent);
            }

            public void RegisterPartial(string name, string template)
            {
                using (var reader = new StringReader(template))
                {
                    handlebars.RegisterTemplate(name, handlebars.Compile(reader));
                }
            }
        }
    }
}
