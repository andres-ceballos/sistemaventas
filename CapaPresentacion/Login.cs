﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using CapaEntidad;

namespace CapaPresentacion
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            List<Usuario> TEST = new CN_Usuario().Listar();

            Usuario objUsuario = new CN_Usuario().Listar().Where(u => u.Documento == txtDocumento.Text && u.Clave == txtContrasena.Text).FirstOrDefault();

            if(objUsuario != null)
            {
                Inicio form = new Inicio();

                form.Show();
                this.Hide();

                form.FormClosing += frm_Closing;

            }else{
                MessageBox.Show("No se encontró el usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
         
        }

        private void frm_Closing(object sender, FormClosingEventArgs e)
        {
            txtDocumento.Text = "";
            txtContrasena.Text = "";
            this.Show();
        }
    }
}
