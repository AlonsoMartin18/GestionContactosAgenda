using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using Entity;

namespace PL
{
    public partial class Form1 : Form
    {
        private readonly ContactoBLL _contactoBLL;
        private List<Contacto> _contactosEnMemoria;
        public Form1()
        {
            InitializeComponent();
            _contactoBLL = new ContactoBLL();
            _contactosEnMemoria = new List<Contacto>();
            CargarContactosDesdeBase();
        }

        private void CargarContactosDesdeBase()
        {
            dgvContactos.DataSource = _contactoBLL.ObtenerTodosLosContactos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
        }

       
        private void btnAgregarContacto_Click(object sender, EventArgs e)
        {
            try
            {
                Contacto contacto = new Contacto
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    CorreoElectronico = txtCorreo.Text,
                    Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text,
                    FechaNacimiento = dtpFechaNacimiento.Value
                };

                // Validación preliminar antes de agregar a la lista
                _contactoBLL.ValidarContacto(contacto, esNuevo: true);

                _contactosEnMemoria.Add(contacto); // Agregar a la lista local
                MessageBox.Show("Contacto agregado a la lista local.");
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Evento para guardar los contactos de la lista local en la base de datos
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_contactosEnMemoria.Count == 0)
                {
                    MessageBox.Show("No hay contactos en la lista local para guardar.");
                    return;
                }

                _contactoBLL.GuardarContactosEnMasa(_contactosEnMemoria);
                MessageBox.Show("Contactos guardados exitosamente.");

                _contactosEnMemoria.Clear(); // Limpiar la lista local después de guardar
                CargarContactosDesdeBase(); // Actualizar la grilla con los datos de la base de datos
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los contactos: " + ex.Message);
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContactos.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvContactos.SelectedRows[0].Index;
                    Contacto contacto = dgvContactos.Rows[rowIndex].DataBoundItem as Contacto;

                    if (contacto != null)
                    {
                        _contactoBLL.EliminarContacto(contacto.ContactoId);
                        MessageBox.Show("Contacto eliminado exitosamente.");
                        CargarContactosDesdeBase();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un contacto para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el contacto: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvContactos.SelectedRows.Count > 0)
                {
                    int rowIndex = dgvContactos.SelectedRows[0].Index;
                    Contacto contacto = dgvContactos.Rows[rowIndex].DataBoundItem as Contacto;

                    if (contacto != null)
                    {
                        // Actualizar los datos desde los campos
                        contacto.Nombre = txtNombre.Text;
                        contacto.Apellido = txtApellido.Text;
                        contacto.CorreoElectronico = txtCorreo.Text;
                        contacto.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text;
                        contacto.FechaNacimiento = dtpFechaNacimiento.Value;

                        // Validar y actualizar en la base de datos
                        _contactoBLL.ActualizarContacto(contacto);
                        MessageBox.Show("Contacto actualizado exitosamente.");
                        CargarContactosDesdeBase();
                        LimpiarCampos();
                    }
                }
                else
                {
                    MessageBox.Show("Seleccione un contacto para editar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al editar el contacto: " + ex.Message);
            }

        }

       

        private void dgvContactos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    Contacto contacto = dgvContactos.Rows[e.RowIndex].DataBoundItem as Contacto;

                    if (contacto != null)
                    {
                        txtNombre.Text = contacto.Nombre;
                        txtApellido.Text = contacto.Apellido;
                        txtCorreo.Text = contacto.CorreoElectronico;
                        txtTelefono.Text = contacto.Telefono;
                        dtpFechaNacimiento.Value = contacto.FechaNacimiento;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar un contacto: " + ex.Message);
            }
        }
    
    }
    
}
