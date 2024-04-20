using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIEjemplo
{
    public partial class Form_secundario : Form
    {
        public Form_Calculadora formPrincipal {  get; set; } //Se crea un puntero al form principal para que, al salir este y cerrsr el otro, se pueda volver!
        public Form_secundario()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_secundario_FormClosing(object sender, FormClosingEventArgs e)
        {
            formPrincipal.Show();
        }
    }
}
