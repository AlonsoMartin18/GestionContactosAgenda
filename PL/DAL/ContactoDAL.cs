using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Entity;
using Mapper;

namespace DAL
{
    public class ContactoDAL
    {
        private readonly ConexionDB _conexionDB = new ConexionDB();

        // Obtener todos los contactos
        public List<Contacto> ObtenerTodosLosContactos()
        {
            List<Contacto> contactos = new List<Contacto>();
            string query = "SELECT * FROM Contacto";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                contactos.Add(ContactoMapper.Map(reader));
                            }
                        }
                    }
                }
                return contactos;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener los contactos: " + ex.Message);
            }
        }

        // Obtener un contacto por ID
        public Contacto ObtenerContactoPorId(int contactoId)
        {
            string query = "SELECT * FROM Contacto WHERE ContactoId = @ContactoId";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ContactoId", contactoId);
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return ContactoMapper.Map(reader);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al obtener el contacto: " + ex.Message);
            }

            return null;
        }

        // Agregar un nuevo contacto
        public void AgregarContacto(Contacto contacto)
        {
            string query = "INSERT INTO Contacto (Nombre, Apellido, CorreoElectronico, Telefono, FechaNacimiento) " +
                           "VALUES (@Nombre, @Apellido, @CorreoElectronico, @Telefono, @FechaNacimiento)";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", contacto.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Telefono", (object)contacto.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al agregar el contacto: " + ex.Message);
            }
        }

        // Actualizar un contacto existente
        public void ActualizarContacto(Contacto contacto)
        {
            string query = "UPDATE Contacto SET Nombre = @Nombre, Apellido = @Apellido, " +
                           "CorreoElectronico = @CorreoElectronico, Telefono = @Telefono, " +
                           "FechaNacimiento = @FechaNacimiento WHERE ContactoId = @ContactoId";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", contacto.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", contacto.Apellido);
                        cmd.Parameters.AddWithValue("@CorreoElectronico", contacto.CorreoElectronico);
                        cmd.Parameters.AddWithValue("@Telefono", (object)contacto.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", contacto.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@ContactoId", contacto.ContactoId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al actualizar el contacto: " + ex.Message);
            }
        }

        // Eliminar un contacto por ID
        public void EliminarContacto(int contactoId)
        {
            string query = "DELETE FROM Contacto WHERE ContactoId = @ContactoId";

            try
            {
                using (SqlConnection conn = new SqlConnection(_conexionDB.ObtenerCadenaConexion()))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ContactoId", contactoId);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el contacto: " + ex.Message);
            }
        }
    }
}
