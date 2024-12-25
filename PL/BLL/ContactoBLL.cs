using System;
using System.Collections.Generic;
using System.Transactions;
using DAL;
using Entity;

namespace BLL
{
    public class ContactoBLL
    {
        private readonly ContactoDAL _contactoDal;

        public ContactoBLL()
        {
            _contactoDal = new ContactoDAL();
        }

        // Validaciones de negocio para Contacto
        public void ValidarContacto(Contacto contacto, bool esNuevo)
        {
            // Validar nombre
            if (string.IsNullOrWhiteSpace(contacto.Nombre) || contacto.Nombre.Length < 2)
            {
                throw new Exception("El nombre debe tener al menos 2 caracteres.");
            }

            // Validar apellido
            if (string.IsNullOrWhiteSpace(contacto.Apellido) || contacto.Apellido.Length < 2)
            {
                throw new Exception("El apellido debe tener al menos 2 caracteres.");
            }

            // Validar correo electrónico
            if (string.IsNullOrWhiteSpace(contacto.CorreoElectronico) || !contacto.CorreoElectronico.Contains("@"))
            {
                throw new Exception("El correo electrónico no tiene un formato válido.");
            }

            // Validar teléfono (opcional)
            if (!string.IsNullOrEmpty(contacto.Telefono) && contacto.Telefono.Length < 7)
            {
                throw new Exception("El teléfono debe tener al menos 7 caracteres si se proporciona.");
            }

            // Validar fecha de nacimiento
            if (contacto.FechaNacimiento > DateTime.Today)
            {
                throw new Exception("La fecha de nacimiento no puede estar en el futuro.");
            }
        }

        // Agregar un contacto
        public void AgregarContacto(Contacto contacto)
        {
            ValidarContacto(contacto, esNuevo: true);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _contactoDal.AgregarContacto(contacto);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al agregar el contacto en la capa de negocio: " + ex.Message);
                }
            }
        }

        // Obtener todos los contactos
        public List<Contacto> ObtenerTodosLosContactos()
        {
            try
            {
                return _contactoDal.ObtenerTodosLosContactos();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los contactos en la capa de negocio: " + ex.Message);
            }
        }

        // Actualizar un contacto existente
        public void ActualizarContacto(Contacto contacto)
        {
            // Verificar que el contacto exista
            if (_contactoDal.ObtenerContactoPorId(contacto.ContactoId) == null)
            {
                throw new Exception("El contacto que intenta actualizar no existe.");
            }

            ValidarContacto(contacto, esNuevo: false);

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _contactoDal.ActualizarContacto(contacto);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el contacto en la capa de negocio: " + ex.Message);
                }
            }
        }

        // Eliminar un contacto
        public void EliminarContacto(int contactoId)
        {
            // Verificar que el contacto exista
            if (_contactoDal.ObtenerContactoPorId(contactoId) == null)
            {
                throw new Exception("El contacto que intenta eliminar no existe.");
            }

            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    _contactoDal.EliminarContacto(contactoId);
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar el contacto en la capa de negocio: " + ex.Message);
                }
            }
        }

        public void GuardarContactosEnMasa(List<Contacto> contactos)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    foreach (var contacto in contactos)
                    {
                        ValidarContacto(contacto, esNuevo: true);
                        _contactoDal.AgregarContacto(contacto);
                    }
                    scope.Complete();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en la carga masiva de contactos: " + ex.Message);
                }
            }
        }
    }
}
