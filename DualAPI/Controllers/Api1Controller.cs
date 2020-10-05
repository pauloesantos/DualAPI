using Microsoft.AspNetCore.Mvc;

namespace DualAPI.Controllers
{
    ///<summary>
    ///API 1
    ///</summary>
    [Route("")]
    public class Api1Controller : ControllerBase
    {
        ///<summary>
        ///GET - Taxa Juros double 0.01
        ///</summary>
        ///<returns>Valor do Juros a ser cobrado</returns>

        [Route("taxaJuros")]
        [HttpGet]
        public double GetTaxaJuros()
        {
            return 0.01;
        }
    }
}