using Microsoft.AspNetCore.Mvc;

namespace DualAPI.Controllers
{
    [Route("")]
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