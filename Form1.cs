using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _3NLIDTS_DiegoGuerrero_5
{
    public partial class Form1 : Form
    {
        // Reglas de validación en un solo lugar (antes estaban repartidas en varios métodos)
        private const int EdadMinima = 1;
        private const int EdadMaxima = 120;
        private const decimal EstaturaMinima = 50;   // centímetros
        private const decimal EstaturaMaxima = 250;  // centímetros

        // Letras (incluye acentos y ñ) separadas por un solo espacio, apóstrofo o guion
        private static readonly Regex PatronTexto = new Regex(@"^\p{L}+(?:[ '\-]\p{L}+)*$");
        private static readonly Regex PatronTelefono = new Regex(@"^[0-9]{10}$");

        // Muestra el error junto a cada campo sin abrir un MessageBox por cada tecla
        private readonly ErrorProvider errores = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            errores.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txbNombre.MaxLength = 50;
            txbApellidos.MaxLength = 50;
            txbTelefono.MaxLength = 10;
            txbEdad.MaxLength = 3;
            txbEstatura.MaxLength = 6;

            // Validación al salir de cada campo (antes TextChanged mostraba un MessageBox por cada tecla)
            txbNombre.Leave += (s, e) => ValidarNombre();
            txbApellidos.Leave += (s, e) => ValidarApellidos();
            txbTelefono.Leave += (s, e) => ValidarTelefono();
            txbEdad.Leave += (s, e) => ValidarEdad();
            txbEstatura.Leave += (s, e) => ValidarEstatura();

            // Teléfono y edad solo aceptan dígitos al escribir
            txbTelefono.KeyPress += SoloDigitos;
            txbEdad.KeyPress += SoloDigitos;
        }

        private Control[] Campos => new Control[] { txbNombre, txbApellidos, txbTelefono, txbEdad, txbEstatura, Genero };

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarDatos())
            {
                MessageBox.Show("Corrija los siguientes datos antes de guardar:\n\n" + ResumenDeErrores(),
                    "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Campos.First(c => errores.GetError(c).Length > 0).Focus();
                return;
            }

            string nombre = txbNombre.Text.Trim();
            string apellidos = txbApellidos.Text.Trim();
            string telefono = txbTelefono.Text.Trim();
            string edad = txbEdad.Text.Trim();
            string estatura = txbEstatura.Text.Trim();
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

            string[] lineas =
            {
                $"Nombre: {nombre}",
                $"Apellidos: {apellidos}",
                $"Telefono: {telefono}",
                $"Edad: {edad}",
                $"Estatura: {estatura}",
                $"Genero: {genero}"
            };
            string mensaje = string.Join(Environment.NewLine, lineas);

            // ruta de almacenamiento (carpeta Documentos del usuario actual)
            string carpetaDestino = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Programacion Avanzada");
            string rutaArchivo = Path.Combine(carpetaDestino, "3NAgoDic26_P05_IA.txt");

            try
            {
                Directory.CreateDirectory(carpetaDestino);
                bool archivoExiste = File.Exists(rutaArchivo);
                using (StreamWriter escritor = new StreamWriter(rutaArchivo, true))
                {
                    if (archivoExiste)
                    {
                        escritor.WriteLine();
                    }
                    escritor.WriteLine(mensaje);
                }
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("No se pudo guardar el archivo:\n" + ex.Message, "Error al guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(mensaje, "Confirmación de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txbNombre.Clear();
            txbApellidos.Clear();
            txbTelefono.Clear();
            txbEstatura.Clear();
            txbEdad.Clear();
            rbFemenino.Checked = false;
            rbMasculino.Checked = false;
            rbOtro.Checked = false;
            foreach (Control campo in Campos)
            {
                errores.SetError(campo, "");
            }
            txbNombre.Focus();
        }

        private bool ValidarDatos()
        {
            // &= evalúa todas las validaciones para marcar cada campo con error
            bool correcto = ValidarNombre();
            correcto &= ValidarApellidos();
            correcto &= ValidarTelefono();
            correcto &= ValidarEdad();
            correcto &= ValidarEstatura();
            correcto &= ValidarGenero();
            return correcto;
        }

        private string ResumenDeErrores()
        {
            return string.Join("\n", Campos
                .Select(c => errores.GetError(c))
                .Where(m => m.Length > 0)
                .Select(m => "- " + m));
        }

        private bool Marcar(Control control, string mensaje)
        {
            errores.SetError(control, mensaje);
            return mensaje.Length == 0;
        }

        private bool ValidarTexto(TextBox caja, string campo)
        {
            string valor = caja.Text.Trim();
            if (valor.Length == 0)
            {
                return Marcar(caja, $"{campo}: campo obligatorio.");
            }
            if (!PatronTexto.IsMatch(valor))
            {
                return Marcar(caja, $"{campo}: solo letras, espacios, apóstrofo o guion.");
            }
            return Marcar(caja, "");
        }

        private bool ValidarNombre() => ValidarTexto(txbNombre, "Nombre");

        private bool ValidarApellidos() => ValidarTexto(txbApellidos, "Apellidos");

        private bool ValidarTelefono()
        {
            bool correcto = PatronTelefono.IsMatch(txbTelefono.Text.Trim());
            return Marcar(txbTelefono, correcto ? "" : "Teléfono: exactamente 10 dígitos.");
        }

        private bool ValidarEdad()
        {
            bool correcto = int.TryParse(txbEdad.Text.Trim(), NumberStyles.None, CultureInfo.InvariantCulture, out int edad)
                && edad >= EdadMinima && edad <= EdadMaxima;
            return Marcar(txbEdad, correcto ? "" : $"Edad: número entero entre {EdadMinima} y {EdadMaxima}.");
        }

        private bool ValidarEstatura()
        {
            // Acepta 167, 167.5 o 167,5 (centímetros)
            string valor = txbEstatura.Text.Trim().Replace(',', '.');
            bool correcto = decimal.TryParse(valor, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out decimal estatura)
                && estatura >= EstaturaMinima && estatura <= EstaturaMaxima;
            return Marcar(txbEstatura, correcto ? "" : $"Estatura: centímetros entre {EstaturaMinima} y {EstaturaMaxima} (ej. 167 o 167.5).");
        }

        private bool ValidarGenero()
        {
            bool correcto = rbFemenino.Checked || rbMasculino.Checked || rbOtro.Checked;
            return Marcar(Genero, correcto ? "" : "Género: seleccione una opción.");
        }

        private void SoloDigitos(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }
    }
}
