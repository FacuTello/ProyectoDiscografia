
namespace Discografia
{
    partial class frmAltaDIsco
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelCanciones = new System.Windows.Forms.Label();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.labelfecha = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblEstilo = new System.Windows.Forms.Label();
            this.lblEdicion = new System.Windows.Forms.Label();
            this.boxEstilo = new System.Windows.Forms.ComboBox();
            this.BoxEdicion = new System.Windows.Forms.ComboBox();
            this.txtFecha = new System.Windows.Forms.DateTimePicker();
            this.labelImagenTapa = new System.Windows.Forms.Label();
            this.txtImagenTapa = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCanciones
            // 
            this.labelCanciones.AutoSize = true;
            this.labelCanciones.Location = new System.Drawing.Point(44, 108);
            this.labelCanciones.Name = "labelCanciones";
            this.labelCanciones.Size = new System.Drawing.Size(122, 13);
            this.labelCanciones.TabIndex = 0;
            this.labelCanciones.Text = "Cantidad de canciones :";
            this.labelCanciones.Click += new System.EventHandler(this.label1_Click);
            // 
            // labelTitulo
            // 
            this.labelTitulo.AutoSize = true;
            this.labelTitulo.Location = new System.Drawing.Point(66, 31);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(39, 13);
            this.labelTitulo.TabIndex = 1;
            this.labelTitulo.Text = "Titulo :";
            // 
            // labelfecha
            // 
            this.labelfecha.AutoSize = true;
            this.labelfecha.Location = new System.Drawing.Point(44, 72);
            this.labelfecha.Name = "labelfecha";
            this.labelfecha.Size = new System.Drawing.Size(103, 13);
            this.labelfecha.TabIndex = 2;
            this.labelfecha.Text = "FechaLanzamiento :";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(175, 108);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(172, 20);
            this.txtCantidad.TabIndex = 2;
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(175, 31);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(172, 20);
            this.txtTitulo.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(47, 282);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(116, 30);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(228, 282);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(119, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblEstilo
            // 
            this.lblEstilo.AutoSize = true;
            this.lblEstilo.Location = new System.Drawing.Point(67, 179);
            this.lblEstilo.Name = "lblEstilo";
            this.lblEstilo.Size = new System.Drawing.Size(38, 13);
            this.lblEstilo.TabIndex = 8;
            this.lblEstilo.Text = "Estilo :";
            // 
            // lblEdicion
            // 
            this.lblEdicion.AutoSize = true;
            this.lblEdicion.Location = new System.Drawing.Point(43, 213);
            this.lblEdicion.Name = "lblEdicion";
            this.lblEdicion.Size = new System.Drawing.Size(87, 13);
            this.lblEdicion.TabIndex = 9;
            this.lblEdicion.Text = "Tipo de Edicion :";
            // 
            // boxEstilo
            // 
            this.boxEstilo.Cursor = System.Windows.Forms.Cursors.Default;
            this.boxEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.boxEstilo.FormattingEnabled = true;
            this.boxEstilo.Location = new System.Drawing.Point(175, 176);
            this.boxEstilo.Name = "boxEstilo";
            this.boxEstilo.Size = new System.Drawing.Size(172, 21);
            this.boxEstilo.TabIndex = 4;
            this.boxEstilo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // BoxEdicion
            // 
            this.BoxEdicion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BoxEdicion.FormattingEnabled = true;
            this.BoxEdicion.Location = new System.Drawing.Point(175, 213);
            this.BoxEdicion.Name = "BoxEdicion";
            this.BoxEdicion.Size = new System.Drawing.Size(172, 21);
            this.BoxEdicion.TabIndex = 5;
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(175, 72);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(172, 20);
            this.txtFecha.TabIndex = 1;
            // 
            // labelImagenTapa
            // 
            this.labelImagenTapa.AutoSize = true;
            this.labelImagenTapa.Location = new System.Drawing.Point(54, 141);
            this.labelImagenTapa.Name = "labelImagenTapa";
            this.labelImagenTapa.Size = new System.Drawing.Size(76, 13);
            this.labelImagenTapa.TabIndex = 13;
            this.labelImagenTapa.Text = "Imagen Tapa :";
            // 
            // txtImagenTapa
            // 
            this.txtImagenTapa.Location = new System.Drawing.Point(175, 141);
            this.txtImagenTapa.Name = "txtImagenTapa";
            this.txtImagenTapa.Size = new System.Drawing.Size(172, 20);
            this.txtImagenTapa.TabIndex = 3;
            this.txtImagenTapa.Leave += new System.EventHandler(this.txtImagenTapa_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(387, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(353, 141);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(28, 23);
            this.btnAgregarImagen.TabIndex = 16;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // frmAltaDIsco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 338);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtImagenTapa);
            this.Controls.Add(this.labelImagenTapa);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.BoxEdicion);
            this.Controls.Add(this.boxEstilo);
            this.Controls.Add(this.lblEdicion);
            this.Controls.Add(this.lblEstilo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.labelfecha);
            this.Controls.Add(this.labelTitulo);
            this.Controls.Add(this.labelCanciones);
            this.Name = "frmAltaDIsco";
            this.Text = "Nuevo Disco";
            this.Load += new System.EventHandler(this.frmAltaDIsco_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCanciones;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Label labelfecha;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblEstilo;
        private System.Windows.Forms.Label lblEdicion;
        private System.Windows.Forms.ComboBox boxEstilo;
        private System.Windows.Forms.ComboBox BoxEdicion;
        private System.Windows.Forms.DateTimePicker txtFecha;
        private System.Windows.Forms.Label labelImagenTapa;
        private System.Windows.Forms.TextBox txtImagenTapa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnAgregarImagen;
    }
}