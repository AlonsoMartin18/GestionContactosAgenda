namespace PL
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnAgregarContacto = new Button();
            dgvContactos = new DataGridView();
            btnGuardar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvContactos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 5);
            label1.Name = "label1";
            label1.Size = new Size(224, 30);
            label1.TabIndex = 0;
            label1.Text = "Gestion De Contactos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 49);
            label2.Name = "label2";
            label2.Size = new Size(118, 15);
            label2.TabIndex = 1;
            label2.Text = "Registro de Contacto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 88);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 131);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 214);
            label5.Name = "label5";
            label5.Size = new Size(112, 15);
            label5.TabIndex = 5;
            label5.Text = "Teléfono (opcional):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(25, 171);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 4;
            label6.Text = "Correo Electrónico:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(25, 258);
            label7.Name = "label7";
            label7.Size = new Size(122, 15);
            label7.TabIndex = 6;
            label7.Text = "Fecha de Nacimiento:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(25, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(230, 23);
            txtNombre.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(25, 145);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(230, 23);
            txtApellido.TabIndex = 8;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(25, 189);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(230, 23);
            txtCorreo.TabIndex = 9;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(25, 232);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(230, 23);
            txtTelefono.TabIndex = 10;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(25, 276);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(230, 23);
            dtpFechaNacimiento.TabIndex = 11;
            // 
            // btnAgregarContacto
            // 
            btnAgregarContacto.Location = new Point(25, 321);
            btnAgregarContacto.Name = "btnAgregarContacto";
            btnAgregarContacto.Size = new Size(200, 34);
            btnAgregarContacto.TabIndex = 12;
            btnAgregarContacto.Text = "Agregar Contacto";
            btnAgregarContacto.UseVisualStyleBackColor = true;
            btnAgregarContacto.Click += btnAgregarContacto_Click;
            // 
            // dgvContactos
            // 
            dgvContactos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvContactos.Location = new Point(287, 89);
            dgvContactos.Name = "dgvContactos";
            dgvContactos.Size = new Size(487, 211);
            dgvContactos.TabIndex = 13;
            dgvContactos.CellClick += dgvContactos_CellClick;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(287, 322);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(148, 34);
            btnGuardar.TabIndex = 14;
            btnGuardar.Text = "Guardar Cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(459, 322);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(148, 34);
            btnEditar.TabIndex = 15;
            btnEditar.Text = "Editar Contacto";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(626, 322);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(148, 34);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "Eliminar Contacto";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(287, 49);
            label8.Name = "label8";
            label8.Size = new Size(130, 20);
            label8.TabIndex = 17;
            label8.Text = "Lista de Contactos";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label8);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvContactos);
            Controls.Add(btnAgregarContacto);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtTelefono);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvContactos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtCorreo;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnAgregarContacto;
        private DataGridView dgvContactos;
        private Button btnGuardar;
        private Button btnEditar;
        private Button btnEliminar;
        private Label label8;
    }
}
