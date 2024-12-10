using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; // Se agrega esta libreria para hacer poder crear los objetos para la conexion a DB
using dominio;

namespace negocio
{
    public class DiscoNegocio
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            
            // Como necesito conectarme a algun lado creo este objeto sqlConnection y le doy el nombre conexion
            SqlConnection conexion = new SqlConnection();
            // Ademas de la conexion voy a necesitar hacer acciones. Asi que creo :
            SqlCommand comando = new SqlCommand();
            // La lectura me va a arroja un set de datos y para guardarlo creo esto : 
            SqlDataReader lector; // no se hace la instancia.

            try
            {
                // Tengo que configurar despues a que servidor me voy a conectar. Dentro del string le tengo 
                // que indica a donde me voy a conectar (saco la dire de sql studio)
                // reemplazo el nombre de la compu por un punto. 
                // Dentro del string y despues del ; tengo que poner a que base de datos me quiero 
                // conectar : 
                // Despues del segundo ; tengo que indicar como me quiero conectar : 
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database =DISCOS_DB; integrated security=true";

                //Como quiero hacer una lectura debo utilizar el objeto creado comando : 
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, t.Id, t.Descripcion as Formato, e.Id, e.Descripcion, d.id from DISCOS d , TIPOSEDICION t, ESTILOS e where d.IdTipoEdicion = t.id and IdEstilo = e.id";

                // lo siguiente es decirle que el comando lo va a ejecutar en esta conexion : 
                comando.Connection = conexion;
                // lo siguiente es abrir la conexion :
                conexion.Open();
                //ejecuto el comando indicado y lo asigno al objeto creado lector. Esto me genera una tabla virtual que se almacena
                //en memoria que lo voy a transformar en una coleccion de objetos.
                // Para transformarlo tengo que crear un while para leer el lector :
                lector = comando.ExecuteReader();


                // Si pudo leer y hay un registro a continuacion me va a dar true pero ademas me va a posicionar un puntero
                // en la siguiente posicion. Cuando empieza se ubica en la posicion 1 de la tabla y para llenar esa fila de la tabla
                // tengo que crearme un un elemento(disco en este caso) auxiliar y lo voy a empezar a cargar con los datos
                // de ese registro
                // Este while en cada vuelta va a reutilizar la variable aux, va a instanciar en cada vuelta y a cada linea
                // de la tabla va ir cargando los datos. 
                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.id = (int)lector["id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.FechaEstreno = (DateTime)lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)lector["CantidadCanciones"];

                    //if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagenTapa"))))
                      //      aux.UrlImagen = (string)lector["UrlImagenTapa"];

                    if (!(lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)lector["UrlImagenTapa"];


                    aux.Edicion = new Formato();
                    aux.Edicion.Id = (int)lector["Id"]; 
                    aux.Edicion.Descripcion = (string)lector["Formato"];//Formato es el alias que le puse en la consulta sql
                    aux.Estilo = new Formato();
                    aux.Estilo.Id = (int)lector["Id"];
                    aux.Estilo.Descripcion = (string)lector["Descripcion"];


                    //Finalmente agrego el disco a la lista
                    lista.Add(aux);
                }

                // cuando de un false el while va a salir y va a retornar la lista pero antes hay que cerrar la conexion
                conexion.Close();

                    return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        public void agregar(Disco nuevo)
        {
            // Con esta linea tengo todo lo necesario para conectarme a la base de datos.
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert Into DISCOS (Titulo, FechaLanzamiento, CantidadCanciones, IdEstilo, IdTipoEdicion, UrlImagenTapa) values ('" + nuevo.Titulo + "',@FechaLanzamiento, " + nuevo.CantidadCanciones + ", @IdEstilo, @IdTipoEdicion, @UrlImagenTapa)");
                datos.setearParametro("@IdEstilo", nuevo.Estilo.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.Edicion.Id);
                datos.setearParametro("@FechaLanzamiento", nuevo.FechaEstreno);
                datos.setearParametro("@UrlImagenTapa", nuevo.UrlImagen);
                datos.ejecutarAccion();
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

        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update DISCOS set Titulo = @titulo, FechaLanzamiento = @fecha, CantidadCanciones = @cantidadcanciones, UrlImagenTapa = @imagen, IdEstilo = @idestilo, IdTipoEdicion = @idedicion  where id = @id");
                datos.setearParametro("@titulo", disco.Titulo);
                datos.setearParametro("@fecha", disco.FechaEstreno);
                datos.setearParametro("@cantidadcanciones", disco.CantidadCanciones);
                datos.setearParametro("@imagen", disco.UrlImagen);
                datos.setearParametro("@idestilo", disco.Estilo.Id);
                datos.setearParametro("@idedicion", disco.Edicion.Id);
                datos.setearParametro("@id", disco.id);

                datos.ejecutarAccion();

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

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from Discos where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Disco> filtrar(string campo, string criterio, string filtro)
    {
        List<Disco> lista = new List<Disco>();
        AccesoDatos datos = new AccesoDatos();
        try
        {
            string consulta = "Select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, t.Id, t.Descripcion as Formato, e.Id, e.Descripcion, d.id from DISCOS d, TIPOSEDICION t, ESTILOS e where d.IdTipoEdicion = t.id And IdEstilo = e.id And ";
            if (campo == "Numero de canciones")
                {
                    switch (criterio)
                    {
                        case "mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "menor a":
                            consulta += "CantidadCanciones < " + filtro;
                            break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;
                    }
                }
                else if (campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "comienza con":
                            consulta += "Titulo like '" + filtro + "%'";
                            break;
                        case "termina con":
                            consulta += "Titulo like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "Titulo like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "comienza con":
                            consulta += "t.Descripcion like '" + filtro + "%' ";
                            break;
                        case "termina con":
                            consulta += "t.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "t.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.id = (int)datos.Lector["id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.FechaEstreno = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.CantidadCanciones = (int)datos.Lector["CantidadCanciones"];

                    //if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagenTapa"))))
                    //      aux.UrlImagen = (string)lector["UrlImagenTapa"];

                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.UrlImagen = (string)datos.Lector["UrlImagenTapa"];


                    aux.Edicion = new Formato();
                    aux.Edicion.Id = (int)datos.Lector["Id"];
                    aux.Edicion.Descripcion = (string)datos.Lector["Formato"];//Formato es el alias que le puse en la consulta sql
                    aux.Estilo = new Formato();
                    aux.Estilo.Id = (int)datos.Lector["Id"];
                    aux.Estilo.Descripcion = (string)datos.Lector["Descripcion"];


                    //Finalmente agrego el disco a la lista
                    lista.Add(aux);
                }
                return lista;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }

    }

}
