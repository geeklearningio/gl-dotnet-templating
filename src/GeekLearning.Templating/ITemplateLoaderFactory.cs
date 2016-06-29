using GeekLearning.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public interface ITemplateLoaderFactory
    {
        ITemplateLoader Create(IStore store);

        ITemplateLoader Create(IStore store, string scope);
    }
}
