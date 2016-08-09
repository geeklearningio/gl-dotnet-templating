namespace GeekLearning.Templating.Handlebars
{
    using HandlebarsDotNet;
    using System.Collections.Generic;
    using System.IO;

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
