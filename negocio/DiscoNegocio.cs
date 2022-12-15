using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using System.Data.SqlClient;

namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            accesoDatos datos = new accesoDatos();
            List<Disco> discos = new List<Disco>();

            try
            {
                datos.setearConsulta("select D.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, E.Descripcion Estilo, T.Descripcion Edicion from DISCOS D, TIPOSEDICION T, ESTILOS E where IdEstilo = E.Id and IdTipoEdicion = T.Id");
                datos.ejecutarLectura();
                while(datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    DateTime fecha = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.Lanzamiento = fecha.ToString("d");
                    aux.Canciones = (int)datos.Lector["CantidadCanciones"];
                    aux.urlImagen = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo = new Estilo();
                    aux.Estilo.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Edicion = new TipoEdicion();
                    aux.Edicion.Descripcion = (string)datos.Lector["Edicion"];
                    
                    
                    discos.Add(aux);
                }

                return discos;


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
