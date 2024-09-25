using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        [HttpGet]
        public decimal Get(decimal a, decimal b)
        {
            return a + b;
        }

        [HttpPost]
        public decimal Add(decimal a, decimal b)
        {
            return a - b;
        }
        [HttpPut]
        public decimal multiplicar(decimal a, decimal b)
        {
            return a * b;
        }

        [HttpDelete]
        public decimal Nmas1(decimal a, decimal b)
        {
            return a *( b + 1);
        }


    }
}
