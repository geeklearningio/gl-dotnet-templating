using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public interface ITemplate
    {
        string Apply(object context);
    }
}
