using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumos.Modelos
{
    public class ModelClientes
    {
        [DisplayName("Codigo")]
        public long Codigo { get; set; }
        [DisplayName("Tipo documento")]
        public string DescripcionDocumento { get; set; }
        [Required]
        [DisplayName("Tipo documento")]
        public int Tipodocumento { get; set; }
        [Required]
        [DisplayName("Identificación")]
        public string Identificacion { get; set; }
        [Required]
        [DisplayName("Nombre completo")]
        public string Nombre { get; set; }
        [Required]
        [DisplayName("Correo electronico")]
        [EmailAddress(ErrorMessage = "Correo electronico invalido")]
        public string Email { get; set; }
        [DisplayName("Numero celular")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Los datos deben ser numericos")]
        [StringLength(maximumLength: 20, MinimumLength = 10, ErrorMessage = "El maximo debe ser de 20 caracteres y minimo de 10 caracteres")]
        public string Celular { get; set; }
        [DisplayName("Dirección de residencia")]
        public string Direccion { get; set; }
        [DisplayName("Dirección de instalación")]
        public string DireccionInstalacion { get; set; }
        
        [DisplayName("Activo?")]
        public bool Activo { get; set; }

    }
}
