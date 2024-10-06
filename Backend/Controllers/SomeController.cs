using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("async")]
        public IActionResult getSync() {

            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            Thread.Sleep(1000);
            Console.WriteLine("Conexion Finalizada");

            Thread.Sleep(1000);
            Console.WriteLine("Conexion envio finalizado");
            stopWatch.Stop();
            return Ok(stopWatch.Elapsed);
        }

        [HttpGet("async1")]
        public async Task<IActionResult> GetAsync()
        {
            var tak1 = new Task(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Finalizacion de la tarea asincrona");
            });

            tak1.Start();
            //Tarea que esta fuera del segmento asincron 
            Console.WriteLine("Finalizacion de la tarea NoAsincrona");
            await tak1;
            Console.WriteLine("Finalizacion de la tarea NoAsincrona Terminado");

            return Ok();
        }

        [HttpGet("async2")]
        public async Task<IActionResult> GetAsync2()
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            stopWatch.Start();
            var tak1 = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Finalizacion de la tarea asincrona");
                return 8;
            });

            stopWatch.Start();
            var tak2 = new Task<int>(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine("Finalizacion de la tarea asincrona");
                return 1;
            });


            tak1.Start();
            tak2.Start();
            //Tarea que esta fuera del segmento asincron 
            Console.WriteLine("Finalizacion de la tarea NoAsincrona");
           var resultado =  await tak1;
            Console.WriteLine("Finalizacion de la tarea NoAsincrona Terminado");
            var resultado2 = await tak2;
            Console.WriteLine("Soy la ultima linea");
            stopWatch.Stop();
            return Ok(resultado + resultado2+" " + stopWatch.Elapsed);
        }

    }

   
}
