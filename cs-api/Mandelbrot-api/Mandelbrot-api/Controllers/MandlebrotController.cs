using Microsoft.AspNetCore.Mvc;

namespace Mandelbrot_api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MandlebrotController : ControllerBase
    {
        private readonly ILogger<MandlebrotController> _logger;

        public MandlebrotController(ILogger<MandlebrotController> logger)
        {
            _logger = logger;
        }

        [HttpGet("~/IsInSet")]
        public ActionResult<bool> Get([FromQuery] Complex C)
        {
            return MandlebrotEngine.IsInTheSet(C);
        }

        [HttpGet("~/ImageOfRange")]
        public ActionResult<byte[]> Get([FromQuery] double minReal, double minImag, double maxReal, double maxImag)
        {
            if (minReal > maxReal || minImag > maxImag)
            {
                return BadRequest();
            }

            var upperLeft = new Complex(minReal, maxImag);
            var lowerRight = new Complex(maxReal, minImag);;
            var image = MandlebrotEngine.GetImageOfRange(upperLeft, lowerRight);
            return ImageConverter.ToByteArray(image);           
        }
    }
}