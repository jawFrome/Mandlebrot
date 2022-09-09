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
            if (C == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            if (Math.Abs(C.Real) > 2 || Math.Abs(C.Imag) > 2)
            {
                return false;
            }

            return MandlebrotEngine.Process(C) < MandlebrotEngine.UpperIterationLimit;
        }
    }
}