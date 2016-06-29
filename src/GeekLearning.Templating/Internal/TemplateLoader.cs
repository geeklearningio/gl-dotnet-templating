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
        //private Dictionary<ITemplateProvider, ITemplateScope> scopes;

        public TemplateLoader(IStore store, IEnumerable<ITemplateProvider> providers, IMemoryCache memoryCache, string scope)
        {
            this.store = store;
            this.providers = providers;
            this.memoryCache = memoryCache;
            //this.scope = memoryCache.GetOrCreateAsync("x_tmpl_inf_scopes", async entry => { })
        }

        public async Task<ITemplate> GetTemplate(string name)
        {
            return await this.memoryCache.GetOrCreateAsync($"x_tmpl_{name}", async entry =>
            {
                entry.SetPriority(CacheItemPriority.High);
                var fileName = (await this.store.List($"{name}.*")).First();
                var provider = this.providers.First(x => x.Extensions.Any(ext => fileName.EndsWith(ext)));

                var scope = await GetScope(provider, name.Substring(Math.Max(0, name.LastIndexOf('/'))));

                return scope.Compile(await this.store.ReadAllText(fileName));
            });
        }

        private async Task<ITemplateProviderScope> GetScope(ITemplateProvider provider, string name)
        {
            return await this.memoryCache.GetOrCreateAsync($"x_tmpl_inf_scopes_{provider.Extensions.First()}_{name}", async entry => {
                entry.SetPriority(CacheItemPriority.High);
                var scope = provider.CreateScope();
                var files = await this.store.List(name);
                foreach (var file in files)
                {
                    var path = file.Split('/');
                    var fileName = path.Last();
                    if (fileName.StartsWith("_") && provider.Extensions.Any(ext=> fileName.EndsWith(ext)))
                    {
                        var partialName = System.IO.Path.GetFileNameWithoutExtension(fileName.Substring(1));
                        scope.RegisterPartial(partialName, await this.store.ReadAllText(file));
                    }
                }
                return scope;
            });
        }
    }
}
