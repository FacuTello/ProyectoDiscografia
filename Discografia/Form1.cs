using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace Discografia
{
    public partial class Form1 : Form
    {
        // Hago este atributo para poder manipular el listado de Discos
        private List<Disco> listaDisco;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();
            cboCampo.Items.Add("Numero de canciones");
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("Formato");
        }

        private void dataDiscos_SelectionChanged(object sender, EventArgs e)
        {
            // primero tengo que tomar el elemento que este seleccionado en la grilla. 
            //El objeto que va a regresar es un objeto pero como yo se que lo que hay en la
            // grilla son discos tengo que hacer el casteo con el tipo de dato.
            // el objeto actual relacionado lo asigno a la variable seleccionado de tipo Disco
            if (dataDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dataDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
            
        }

        private void cargar()
        {
            // Aca tengo que invocar a la lectura de la base de datos
            DiscoNegocio negocio = new DiscoNegocio();


            try
            {
                listaDisco = negocio.listar();

                // a la grilla le voy a asignar el listado de datos que se obtiene de la base de datos.
                //Datasource recibe los datos y los modela en la grilla. dataDiscos es la grilla.
                // Para leer imagenes no lo asigno directamente porque necesito manipular
                // lo que me arroje DataSource y ya no solo verlo. 
                dataDiscos.DataSource = listaDisco;
                ocultarColumnas();

                // Le asigno al picturebox de la ventana la imagen del primer registro
                cargarImagen(listaDisco[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
            
        private void ocultarColumnas()
        {
            dataDiscos.Columns["UrlImagen"].Visible = false;
            dataDiscos.Columns["id"].Visible = false;
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

        private void dataDiscos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaDIsco alta = new frmAltaDIsco();
            alta.ShowDialog();
            cargar();
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            //Con esto tengo el disco seleccionado en la grilla
            seleccionado = (Disco)dataDiscos.CurrentRow.DataBoundItem;
            frmAltaDIsco modificar = new frmAltaDIsco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            DiscoNegocio negocio = new DiscoNegocio();

            
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas Seguro?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dataDiscos.CurrentRow.DataBoundItem;
                    negocio.eliminar(seleccionado.id);
                    MessageBox.Show("Eliminacion completa");
                    cargar();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor complete el campo para buscar");
                return true;
            }

            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor complete el criterio para buscar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Numero de canciones")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado))
                {
                    MessageBox.Show("El campo debe tener al menos un numero para buscar");
                    return true;
                }

                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo puede ingresar numeros para buscar");
                    return true;
                }
            }
                

            return false;
        }

        private bool soloNumeros(string cadena)
        {
              foreach(char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            DiscoNegocio negocio = new DiscoNegocio();
            
            try
            {
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCampo.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                dataDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            // no hago instancia porque la lista filtrada va a salir del filtro. Es innecesario
            //crear una lista vacia. 
            List<Disco> listafiltrada;

            string filtro = txtFiltro.Text;

            if (filtro != "")
            {
                //el findall es una suerte de foreach que va a recorrer los registros y va a separar
                //cuales corresponden a la condicion ingresada y cuales no.
                listafiltrada = listaDisco.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Edicion.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listafiltrada = listaDisco;
            }


            // limpio la grilla de lo que haya
            dataDiscos.DataSource = null;

            // le agrego la lista filtrada
            dataDiscos.DataSource = listafiltrada;
            ocultarColumnas();
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();

            if(opcion == "Numero de canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("mayor a");
                cboCriterio.Items.Add("menor a");
                cboCriterio.Items.Add("igual a");
            }else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("comienza con");
                cboCriterio.Items.Add("termina con");
                cboCriterio.Items.Add("contiene");
            }
                
        }
    }
}
