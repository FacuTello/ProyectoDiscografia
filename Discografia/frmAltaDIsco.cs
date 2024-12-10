using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;
using System.Configuration;

namespace Discografia
{
    public partial class frmAltaDIsco : Form
    {
        private Disco disco = null;

        private OpenFileDialog archivo = null;
        public frmAltaDIsco()
        {
            InitializeComponent();
        }

        public frmAltaDIsco(Disco disco)
        {
            InitializeComponent();
            this.disco = disco;
            Text = "Modificar Disco";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            
            DiscoNegocio negocio = new DiscoNegocio();

            try
            {
                if (disco == null)
                    disco = new Disco();

                disco.Titulo = txtTitulo.Text;
                disco.FechaEstreno = txtFecha.Value;
                disco.CantidadCanciones = int.Parse(txtCantidad.Text);
                disco.UrlImagen = txtImagenTapa.Text;
                disco.Estilo = (Formato)boxEstilo.SelectedItem;
                disco.Edicion = (Formato)BoxEdicion.SelectedItem;

                if(disco.id != 0)
                {
                    negocio.modificar(disco);
                    MessageBox.Show("Se modifico el disco correctamente");
                }
                else
                {
                    negocio.agregar(disco);
                    MessageBox.Show("Se agrego el disco correctamente");
                }

                // Guardo la imagen si la levanto localmente 

                if (archivo != null && !(txtImagenTapa.Text.ToUpper().Contains("HTTP")))   
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmAltaDIsco_Load(object sender, EventArgs e)
        {
            // tengo que cargar los desplegables con la opcion que hay en la bd

            FormatoNegocio formatonegocio = new FormatoNegocio();

            try
            {
                BoxEdicion.DataSource = formatonegocio.listar();
                BoxEdicion.ValueMember = "Id";
                BoxEdicion.DisplayMember = "Descripcion";
                boxEstilo.DataSource = formatonegocio.listar2();
                boxEstilo.ValueMember = "Id";
                boxEstilo.DisplayMember = "Descripcion";

                if (disco != null)
                {
                    txtTitulo.Text = disco.Titulo;
                    txtFecha.Value = disco.FechaEstreno;
                    txtCantidad.Text = disco.CantidadCanciones.ToString();
                    txtImagenTapa.Text = disco.UrlImagen;
                    cargarImagen(disco.UrlImagen);
                    BoxEdicion.SelectedValue = disco.Edicion.Id;
                    boxEstilo.SelectedValue = disco.Estilo.Id;

                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtImagenTapa_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtImagenTapa.Text);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {

                pictureBox1.Load("https://t4.ftcdn.net/jpg/05/17/53/57/360_F_517535712_q7f9QC9X6TQxWi6xYZZbMmw5cnLMr279.jpg");

            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            // para levantar una imagen de la computadora hay que crear este objeto 
            archivo = new OpenFileDialog();

            // aplico un filter para que solo me permita archivos jpg
            archivo.Filter = "jpg|*.jpg; |png|*.png";
            
            // si elegi un archivo y puse aceptar hace lo siguiente
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                txtImagenTapa.Text = archivo.FileName;
                cargarImagen(archivo.FileName);

                // guardo el archivo seleccionado en una carpeta 
                // File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);
            }
        }
    }
}
