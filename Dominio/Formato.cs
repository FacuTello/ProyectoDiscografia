using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio

{
   public class Formato
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }


        // sobreescribo la funcion tostring para que en la grilla me muestre la descripcion y no el objeto. 
        //Cuando no especifico que quiero mostrar del objeto el sistema me arroja el nombre del objeto invocando al tostring.
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
