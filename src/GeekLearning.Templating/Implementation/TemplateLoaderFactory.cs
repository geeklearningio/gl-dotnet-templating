using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekLearning.Storage;

namespace GeekLearning.Templating.Implementation
{
    public class TemplateLoaderFactory : ITemplateLoaderFactory
    {
        private readonly IEnumerable<ITemplateProvider> providers;

        public TemplateLoaderFactory(IEnumerable<ITemplateProvider> providers)
        {
            this.providers = providers;
        }

        public ITemplateLoader Create(IStore store)
        {
            return new TemplateLoader(store, providers);
        }
    }
}
