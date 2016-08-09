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
        [HttpGet]
        public async Task<string> Get([FromQuery]InvitationContext value)
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

        // POST api/values
        [HttpGet("2")]
        public async Task<string> Get2([FromQuery]InvitationContext value)
        {
            try
            {
                return await templates.ApplyInvitation2Template(value);
            }
            catch (InvalidContextException ice)
            {
                return ice.InnerException.Message;
            }
        }

        [HttpGet("3")]
        public async Task<string> Get3([FromQuery]InvitationContext value)
        {
            try
            {
                return await templates.ApplyInvitation3Template(value);
            }
            catch (InvalidContextException ice)
            {
                return ice.InnerException.Message;
            }
        }
    }
}
