using Microsoft.AspNetCore.Mvc;

namespace DualAPI.Controllers
{
    [Route("api1")]
    public class Api1Controller : ControllerBase
    {
        [Route("taxaJuros")]
        [HttpGet]
        public double GetTaxaJuros()
        {
            return 0.01;
        }
    }
}