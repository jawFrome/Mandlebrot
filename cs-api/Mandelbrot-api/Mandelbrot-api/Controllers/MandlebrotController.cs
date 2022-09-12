using Microsoft.AspNetCore.Mvc;

namespace Mandelbrot_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MandlebrotController : ControllerBase
    {
        private readonly ILogger<MandlebrotController> _logger;

        public MandlebrotController(ILogger<MandlebrotController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "IsInSet")]
        public ActionResult<bool> Get([FromQuery] Complex C)
        {
            return MandlebrotEngine.IsInTheSet(C);
        }
    }
}