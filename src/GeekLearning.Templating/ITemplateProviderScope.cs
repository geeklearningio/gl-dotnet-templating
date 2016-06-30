using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public interface ITemplateProviderScope
    {
        ITemplate Compile(string templateContent);

        void RegisterPartial(string name, string template);

    }
}
