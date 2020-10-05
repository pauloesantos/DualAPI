using Microsoft.AspNetCore.Mvc;
using DualAPI.ValueObjects;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace DualAPI.Controllers
{
    [Route("")]
    public class Api2Controller : ControllerBase
    {
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
        [Route("showmethecode")]
        [HttpGet]
        public string GetShowMeTheCode()
        {
            return "https://github.com/pauloesantos";
        }
    }
}