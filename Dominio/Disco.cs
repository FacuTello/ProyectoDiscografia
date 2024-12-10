using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace dominio
{
    public class Disco
    {
        public int id { get; set; }

        // Se usa un displayname para que las columnas de la grilla se corrigan.
        [DisplayName("Título")]
        public string Titulo { get; set; }

        [DisplayName("Fecha de estreno")]
        public DateTime FechaEstreno { get; set; }

        [DisplayName("Cantidad de canciones")]
        public int CantidadCanciones { get; set; }

        [DisplayName("Imagen Tapa")]
        public string UrlImagen { get; set; }

        [DisplayName("Edición")]
        public Formato Edicion { get; set; }

        public Formato Estilo { get; set; }
    }
}
