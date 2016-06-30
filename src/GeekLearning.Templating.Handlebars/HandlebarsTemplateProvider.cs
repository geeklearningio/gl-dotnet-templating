namespace GeekLearning.Templating.Handlebars
{
    using System.Collections.Generic;

    public class HandlebarsTemplateProvider: ITemplateProvider
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
    }
}
