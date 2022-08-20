using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Modelos
{
    public class Clientes
    {
        public long Codigo { get; set; }
        public int Tipodocumento { get; set; }
        public string Identificacion { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string DireccionInstalacion { get; set; }
        public bool Activo { get; set; }
    }
}
