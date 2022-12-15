using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace dominio
{
    public class Disco
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Lanzamiento { get; set; }
        public int Canciones { get; set; }
        public string urlImagen { get; set; }
        public Estilo Estilo { get; set; }
        public TipoEdicion Edicion { get; set; }
        
    }
}
