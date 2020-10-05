using Microsoft.AspNetCore.Mvc;
using DualAPI.ValueObjects;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace DualAPI.Controllers
{
    ///<summary>
    ///API 2
    ///</summary>
    [Route("")]
    public class Api2Controller : ControllerBase
    {
        ///<summary>
        ///Calcula Juros
        ///</summary>
        ///<param name="ValorInicial"></param>
        ///<param name="Meses"></param>
        ///<returns>Valor Juros composto</returns>

        [Route("calculajuros")]
        [HttpGet]
        public string GetCalculaJuros([FromQuery] ParamQueryCalculaJuros valores)
        {
            decimal juros = 0.0m;

            //HttpClientHandler para simular um certificado ssl local
            using (var httpClientHandler = new HttpClientHandler())
            {
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = httpClient.GetAsync("https://localhost:5001/taxaJuros").Result)
                    {
                        response.EnsureSuccessStatusCode();
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        juros = JsonConvert.DeserializeObject<Decimal>(apiResponse);
                    }

                }
            }
            var valorFinal = Convert.ToDecimal(Math.Pow(Convert.ToDouble(valores.ValorInicial * (1 + juros)), valores.Meses));

            return valorFinal.ToString("n2");
        }
        ///<summary>
        ///Show me the Code
        ///</summary>
        ///<returns>Link da onde está o código fonte</returns>
        [Route("showmethecode")]
        [HttpGet]
        public string GetShowMeTheCode()
        {
            return "https://github.com/pauloesantos/DualAPI";
        }
    }
}