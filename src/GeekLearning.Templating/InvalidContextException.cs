using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekLearning.Templating
{
    public class InvalidContextException: Exception
    {
        public InvalidContextException(Exception innerException): base("Invalid template generation context.", innerException)
        {

        }
    }
}
