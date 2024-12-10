using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
     public class FormatoNegocio
    {
        public List<Formato> listar()
        {
            List<Formato> lista = new List<Formato>();
            // Nace un objeto que tiene un lector, un comando y una conexion. 
            // El comando y la conexion tienen instancia y ademas tiene una cadena de 
            // conexion configurada.
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearConsulta("Select Id, descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Formato aux = new Formato();
                    aux.Id = (int)datos.Lector["id"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];

                    lista.Add(aux);
                }


                return lista;
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
        public List<Formato> listar2()
        {
            List<Formato> lista2 = new List<Formato>();
            AccesoDatos datos2 = new AccesoDatos();

            try
            {
                datos2.setearConsulta("Select Id, descripcion from ESTILOS");
                datos2.ejecutarLectura();

                while (datos2.Lector.Read())
                {
                    Formato aux = new Formato();
                    aux.Id = (int)datos2.Lector["id"];
                    aux.Descripcion = (string)datos2.Lector["descripcion"];

                    lista2.Add(aux);
                }


                return lista2;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }
    }

    
}
