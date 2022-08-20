using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumos.Modelos
{
    public class ModelTipoDocumentos
    {
        [Required]
        public int Codigo { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
