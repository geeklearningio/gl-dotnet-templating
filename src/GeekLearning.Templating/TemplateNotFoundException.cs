
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public class TemplateNotFoundException : Exception
    {
        public TemplateNotFoundException(string name): base($"Template with name: `{name}` does not exist.")
        {
        }
    }
}
