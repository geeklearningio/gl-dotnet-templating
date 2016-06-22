using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GeekLearning.Templating.BasicSample.Controllers
{
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private EmailTemplates templates;

        public TestController(EmailTemplates templates)
        {
            this.templates = templates;
        }

        // POST api/values
        [HttpPost]
        public async Task<string> Post([FromBody]InvitationContext value)
        {
            try
            {
                return await templates.ApplyInvitationTemplate(value);
            }
            catch (InvalidContextException ice)
            {
                return ice.InnerException.Message;
            }
        }
    }
}
