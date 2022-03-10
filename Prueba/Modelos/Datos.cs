using System;
using System.ComponentModel.DataAnnotations;

namespace Prueba.Modelos
{

    public class Cliente
    {

        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Pais { get; set; }
        [Required]
        public string Tipo { get; set; }



    }
}
