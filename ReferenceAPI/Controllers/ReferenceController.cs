using System.Web.Http;
using ReferenceAPI.Services;
using ReferenceAPI.Setting;

namespace ReferenceAPI.Controllers
{
    [RoutePrefix("api")]
    public class ReferenceController : ApiController
    {
        private readonly IMathService _mathService;
        private readonly IStringService _stringService;
        private readonly IShapeService _shapeService;
        private readonly ITokenSettings _tokenSettings;

        public ReferenceController(IMathService mathService, IStringService stringService, IShapeService shapeService, ITokenSettings tokenSettings)
        {
            _mathService = mathService;
            _stringService = stringService;
            _shapeService = shapeService;
            _tokenSettings = tokenSettings;
        }
        
        [HttpGet]
        [Route("ReverseWords")]
        public IHttpActionResult ReverseWords([FromUri] string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
            {
                return Ok(sentence);
            }

            var response = _stringService.ReverseWords(sentence);
            return Ok(response);
        }
        
        [HttpGet]
        [Route("TriangleType")]
        public IHttpActionResult TriangleType(long a, long b, long c)
        {
            var response = _shapeService.GetTriangleType(a, b, c);
            return Ok(response.ToString());
        }

        [HttpGet]
        [Route("Fibonacci")]
        public IHttpActionResult Fibonacci(long n)
        {
            const int maxLimit = 92;
            const int minLimit = -92;
            if(n < minLimit || n > maxLimit)
            {
                return BadRequest();
            }

            var response = _mathService.FibonacciValue((int)n);
            return Ok(response);
        }
        
        [HttpGet]
        [Route("Token")]
        public IHttpActionResult Token()
        {
            return Ok(_tokenSettings.Token);
        }
    }
}



