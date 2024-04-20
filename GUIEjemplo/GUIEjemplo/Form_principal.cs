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
    public partial class Form_Calculadora : Form
    {
        public Form_Calculadora()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Operador1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Suma_Click(object sender, EventArgs e)
        {
            int valor1 = int.Parse(textBox_Operador1.Text);
            int valor2 = int.Parse(textBox_Operador2.Text);

            label_Resultado.Text = (valor1 + valor2).ToString();
        }

        private void button_Resta_Click(object sender, EventArgs e)
        {
            int valor1 = int.Parse(textBox_Operador1.Text);
            int valor2 = int.Parse(textBox_Operador2.Text);

            label_Resultado.Text = (valor1 - valor2).ToString();
        }

        private void button_Multiplicar_Click(object sender, EventArgs e)
        {
            int valor1 = int.Parse(textBox_Operador1.Text);
            int valor2 = int.Parse(textBox_Operador2.Text);

            label_Resultado.Text = (valor1 * valor2).ToString();
        }

        private void button_Dividir_Click(object sender, EventArgs e)
        {
            int valor1 = int.Parse(textBox_Operador1.Text);
            int valor2 = int.Parse(textBox_Operador2.Text);

            try
            {
                label_Resultado.Text = (valor1 / valor2).ToString();
            }catch (ArithmeticException) 
            {
                MessageBox.Show("Error: No se puede dividir entre 0!");
            }
        }

        private void button_Multiplicar_MouseEnter(object sender, EventArgs e) //Evento para que el boton se escape cuando se pasa por encima
        {
            int ancho = ActiveForm.Width;
            int alto = ActiveForm.Height;

            Random random = new Random();
            int x = random.Next(0, ancho);
            int y = random.Next(0, alto); //Se pillan dos variables aleatorias para los ejes

            button_Multiplicar.Location = new Point(x - button_Multiplicar.Width, y-button_Multiplicar.Height); 
            //Se calcula la posicion, teniendo en cuenta el tamaño del boton para que no vaya fuera
        }

        private void button1_Click(object sender, EventArgs e) //Como fluir entre secundarios
        {
            Form_secundario formularioSecundario = new Form_secundario();

            formularioSecundario.formPrincipal = this; //Inicializas el puntero para que se sepa que el form principal es este, pudiendo así volver al cerrarse
            formularioSecundario.Show();

            this.Hide(); //Escondemos el formulario actual
        }

        private void Form_principal_Load(object sender, EventArgs e)
        {
            label_Resultado.Text = "0";
        }
    }
}
