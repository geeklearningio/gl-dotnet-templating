namespace GeekLearning.Templating.BasicSample.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private EmailTemplates templates;

        public TestController(EmailTemplates templates)
        {
            this.templates = templates;
        }

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
