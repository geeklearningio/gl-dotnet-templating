namespace GeekLearning.Templating.Mustache
{
    using System.Collections.Generic;

    public class MustacheSharpTemplateProvider : ITemplateProvider
    {
        public MustacheSharpTemplateProvider()
        {
            this.MimeTypes = new HashSet<string>() { "text/x-mustache-template" };
            this.Extensions = new HashSet<string>() { ".mustache" };
        }

        public ISet<string> MimeTypes { get; }

        public ISet<string> Extensions { get; }

        public ITemplate Compile(string templateContent)
        {
            return new MustacheSharpTemplate(templateContent);
        }
    }
}
