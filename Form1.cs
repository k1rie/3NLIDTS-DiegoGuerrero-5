using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _3NLIDTS_DiegoGuerrero_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Declaración de manejadores/controladores de eventos
            txbNombre.TextChanged += ValidarNombre;
            txbApellidos.TextChanged += ValidarApellidos;
            txbEdad.TextChanged += ValidarEdad;
            txbEstatura.TextChanged += ValidarEstatura;
            txbTelefono.Leave += ValidarTelefono;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txbNombre.Text;
            string apellidos = txbApellidos.Text;
            string telefono = txbTelefono.Text;
            string edad = txbEdad.Text;
            string estatura = txbEstatura.Text;
            string genero = "";
            if (rbFemenino.Checked)
            {
                genero = "Femenino";
            }
            else if (rbMasculino.Checked)
            {
                genero = "Masculino";
            }
            else if (rbOtro.Checked)
            {
                genero = "Otro";
            }
            string mensaje = $" Nombre: {nombre}\n\r Apellidos: {apellidos}\n\r Telefono: {telefono}\n\r Edad: {edad}\n\r Estatura: {estatura}\n\r Genero: {genero}";

            // ruta de almacenamiento (carpeta Documentos del usuario actual)
            string carpetaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Programacion Avanzada");
            Directory.CreateDirectory(carpetaDestino);
            string rutaArchivo = Path.Combine(carpetaDestino, "3NAgoDic26_P05.txt");

            bool ArchivoExiste = File.Exists(rutaArchivo);
            using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
            {
                if (ArchivoExiste)
                {
                    escritor.WriteLine();
                }
                escritor.WriteLine(mensaje);

            }
            MessageBox.Show(mensaje, "Confirmación de resgistro", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNombre.Clear();
            txbApellidos.Clear();
            txbTelefono.Clear();
            txbEstatura.Clear();
            txbEdad.Clear();
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            rbOtro.Checked = false;
        }

        private void ValidarNombre(object sender, EventArgs e)
        {
            TextBox textboxLocal = (TextBox)sender;
            if (!EsTextoValidoN(textboxLocal.Text))
            {
                MessageBox.Show("Por favor ingrese un Nombre valido", "Error Nombre", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool EsTextoValidoN(string Valor)
        {
            return Regex.IsMatch(Valor, @"^[a-zA-Z\s]+$");
        }

        private void ValidarApellidos(object sender, EventArgs e)
        {
            TextBox textboxLocal = (TextBox)sender;
            if (!EsTextoValidoA(textboxLocal.Text))
            {
                MessageBox.Show("Por favor ingrese un Apellido valido", "Error Apellido", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private bool EsTextoValidoA(string Valor)
        {
            return Regex.IsMatch(Valor, @"^[a-zA-Z\s]+");
        }

        private void ValidarEdad(object sender, EventArgs e)
        {
            TextBox textboxLocal = (TextBox)sender;
            if (!EsEnteroValido(textboxLocal.Text))
            {
                MessageBox.Show("Por favor ingrese una edad valida", "Error edad", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                textboxLocal.Clear();
            }
        }

        private bool EsEnteroValido(string valor)
        {
            int resultado;
            return int.TryParse(valor, out resultado);
        }

        private void ValidarEstatura(object sender, EventArgs e)
        {
            TextBox textboxLocal = (TextBox)sender;
            if (!EsDecimalValido(textboxLocal.Text))
            {
                MessageBox.Show("Por favor ingrese una estatura valida", "Error estatura", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                textboxLocal.Clear();
            }
        }

        private bool EsDecimalValido(string valor)
        {
            decimal resultado;
            return decimal.TryParse(valor, out resultado);
        }

        private void ValidarTelefono(object sender, EventArgs e)
        {
            TextBox textboxLocal = (TextBox)sender;
            if (!TelefonoValido(textboxLocal.Text))
            {
                MessageBox.Show("Escriba un telefono valido", "Error Telefono", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                textboxLocal.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                textboxLocal.BackColor = System.Drawing.Color.Green;
            }
        }

        private bool TelefonoValido(string valor)
        {
            long resultado;
            return long.TryParse(valor, out resultado)
            && valor.Length == 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
