using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeekLearning.Storage;
using Microsoft.Extensions.Caching.Memory;

namespace GeekLearning.Templating.Internal
{
    public class TemplateLoader : ITemplateLoader
    {
        private IMemoryCache memoryCache;
        private IEnumerable<ITemplateProvider> providers;
        private IStore store;

        public TemplateLoader(IStore store, IEnumerable<ITemplateProvider> providers, IMemoryCache memoryCache)
        {
            this.store = store;
            this.providers = providers;
            this.memoryCache = memoryCache;
        }

        public async Task<ITemplate> GetTemplate(string name)
        {
            return await this.memoryCache.GetOrCreateAsync(name, async entry =>
            {
                entry.SetPriority(CacheItemPriority.High);
                var fileName = (await this.store.List($"{name}.*")).First();
                var provider = this.providers.First(x => x.Extensions.Any(ext => fileName.EndsWith(ext)));
                return provider.Compile(await this.store.ReadAllText(fileName));
            });
        }
    }
}
