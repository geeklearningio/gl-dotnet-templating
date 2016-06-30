namespace GeekLearning.Templating
{
    using System.Collections.Generic;

    public interface ITemplateProvider
    {
        ITemplate Compile(string templateContent);

        ISet<string> MimeTypes { get; }

        ISet<string> Extensions { get; }
    }
}
