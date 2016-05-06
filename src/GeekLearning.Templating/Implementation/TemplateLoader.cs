using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekLearning.Storage;

namespace GeekLearning.Templating.Implementation
{
    public class TemplateLoader: ITemplateLoader
    {
        private IEnumerable<ITemplateProvider> providers;
        private IStore store;

        public TemplateLoader(IStore store, IEnumerable<ITemplateProvider> providers)
        {
            this.store = store;
            this.providers = providers;
        }

        public async Task<ITemplate> GetTemplate(string name)
        {
            return this.providers.First().Compile(await this.store.ReadAllText(name));
        }
    }
}
