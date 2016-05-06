using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public interface ITemplateLoader
    {
        Task<ITemplate> GetTemplate(string name);
    }
}
