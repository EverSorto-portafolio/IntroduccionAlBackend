using Backend.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomServices _singleto;
        private IRandomServices _rScope;
        private IRandomServices _rtransient;

        private IRandomServices _singleto2;
        private IRandomServices _rScope2;
        private IRandomServices _rtransient2;

        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomServices randomSingleton,
            [FromKeyedServices("randomScope")] IRandomServices randomServicesScope,
            [FromKeyedServices("randomTrasient")] IRandomServices randomTrasient,
             [FromKeyedServices("randomSingleton")] IRandomServices randomSingleton2,
            [FromKeyedServices("randomScope")] IRandomServices randomServicesScope2,
            [FromKeyedServices("randomTrasient")] IRandomServices randomTrasient2
            ) {
            _singleto = randomSingleton;
            _rScope =  randomServicesScope;
            _rtransient = randomTrasient;

            _singleto2 = randomSingleton2;
            _rScope2 = randomServicesScope2;
            _rtransient2 = randomTrasient2;
        }
        [HttpGet]
        public ActionResult<Dictionary<string, int>> Get() {
            var result = new Dictionary<string, int>();

            result.Add("Singleton 1", _singleto.Value);
            result.Add("Scope 1", _rScope.Value);
            result.Add("Transient1", _rtransient.Value);

            result.Add("Singleton 2", _singleto2.Value);
            result.Add("Scope 2", _rScope2.Value);
            result.Add("Transient2", _rtransient2.Value);

            return result;
        }

    }
}
