using System.ComponentModel.DataAnnotations;

namespace DualAPI.ValueObjects
{
    public class ParamQueryCalculaJuros
    {
        [Required]
        public decimal ValorInicial { get; set; }
        [Required]
        public int Meses { get; set; }
    }
}