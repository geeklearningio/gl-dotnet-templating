using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public interface ITemplateProvider
    {
        ITemplate Compile(string templateContent);

        ISet<string> MimeTypes { get; }
        ISet<string> Extensions { get; }
    }
}
