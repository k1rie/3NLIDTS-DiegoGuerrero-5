namespace _3NLIDTS_DiegoGuerrero_5
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            txbNombre = new TextBox();
            txbEdad = new TextBox();
            txbTelefono = new TextBox();
            txbApellidos = new TextBox();
            txbEstatura = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            Genero = new GroupBox();
            rbOtro = new RadioButton();
            rbMasculino = new RadioButton();
            rbFemenino = new RadioButton();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            Genero.SuspendLayout();
            SuspendLayout();
            // 
            // txbNombre
            // 
            txbNombre.Location = new Point(299, 50);
            txbNombre.Name = "txbNombre";
            txbNombre.Size = new Size(100, 23);
            txbNombre.TabIndex = 0;
            // 
            // txbEdad
            // 
            txbEdad.Location = new Point(299, 137);
            txbEdad.Name = "txbEdad";
            txbEdad.Size = new Size(100, 23);
            txbEdad.TabIndex = 1;
            // 
            // txbTelefono
            // 
            txbTelefono.Location = new Point(299, 108);
            txbTelefono.Name = "txbTelefono";
            txbTelefono.Size = new Size(100, 23);
            txbTelefono.TabIndex = 2;
            // 
            // txbApellidos
            // 
            txbApellidos.Location = new Point(299, 79);
            txbApellidos.Name = "txbApellidos";
            txbApellidos.Size = new Size(100, 23);
            txbApellidos.TabIndex = 3;
            // 
            // txbEstatura
            // 
            txbEstatura.Location = new Point(299, 166);
            txbEstatura.Name = "txbEstatura";
            txbEstatura.Size = new Size(100, 23);
            txbEstatura.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(242, 53);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(242, 82);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 7;
            label2.Text = "Apellidos";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(242, 111);
            label3.Name = "label3";
            label3.Size = new Size(53, 15);
            label3.TabIndex = 8;
            label3.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(260, 140);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 9;
            label4.Text = "Edad";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 169);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 10;
            label5.Text = "Estatura";
            // 
            // Genero
            // 
            Genero.Controls.Add(rbOtro);
            Genero.Controls.Add(rbMasculino);
            Genero.Controls.Add(rbFemenino);
            Genero.Location = new Point(242, 195);
            Genero.Name = "Genero";
            Genero.Size = new Size(276, 100);
            Genero.TabIndex = 11;
            Genero.TabStop = false;
            Genero.Text = "Genero";
            // 
            // rbOtro
            // 
            rbOtro.AutoSize = true;
            rbOtro.Location = new Point(193, 42);
            rbOtro.Name = "rbOtro";
            rbOtro.Size = new Size(49, 19);
            rbOtro.TabIndex = 2;
            rbOtro.TabStop = true;
            rbOtro.Text = "Otro";
            rbOtro.UseVisualStyleBackColor = true;
            // 
            // rbMasculino
            // 
            rbMasculino.AutoSize = true;
            rbMasculino.Location = new Point(107, 42);
            rbMasculino.Name = "rbMasculino";
            rbMasculino.Size = new Size(80, 19);
            rbMasculino.TabIndex = 1;
            rbMasculino.TabStop = true;
            rbMasculino.Text = "Masculino";
            rbMasculino.UseVisualStyleBackColor = true;
            // 
            // rbFemenino
            // 
            rbFemenino.AutoSize = true;
            rbFemenino.Location = new Point(23, 42);
            rbFemenino.Name = "rbFemenino";
            rbFemenino.Size = new Size(78, 19);
            rbFemenino.TabIndex = 0;
            rbFemenino.TabStop = true;
            rbFemenino.Text = "Femenino";
            rbFemenino.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(354, 314);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(260, 314);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 13;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(Genero);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txbEstatura);
            Controls.Add(txbApellidos);
            Controls.Add(txbTelefono);
            Controls.Add(txbEdad);
            Controls.Add(txbNombre);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Genero.ResumeLayout(false);
            Genero.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txbNombre;
        private TextBox txbEdad;
        private TextBox txbTelefono;
        private TextBox txbApellidos;
        private TextBox txbEstatura;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private GroupBox Genero;
        private RadioButton rbOtro;
        private RadioButton rbMasculino;
        private RadioButton rbFemenino;
        private Button btnGuardar;
        private Button btnLimpiar;
    }
}
