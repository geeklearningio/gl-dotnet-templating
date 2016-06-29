using GeekLearning.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating.BasicSample
{
    public class EmailTemplates : TemplateCollectionBase
    {
        public EmailTemplates(IStorageFactory storageFactory, ITemplateLoaderFactory templateLoaderFactory) : base("Templates", storageFactory, templateLoaderFactory)
        {

        }

        public Task<string> ApplyInvitationTemplate(InvitationContext context)
        {
            return this.LoadAndApplyTemplate("invitation", context);
        }

        public Task<string> ApplyInvitation2Template(InvitationContext context)
        {
            return this.LoadAndApplyTemplate("invitation2", context);
        }
    }
}
