using System;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using Entity;

namespace Mapper
{
    public static class ContactoMapper
    {
        public static Contacto Map(SqlDataReader reader)
        {
            return new Contacto
            {
                ContactoId = Convert.ToInt32(reader["ContactoId"]),
                Nombre = reader["Nombre"].ToString(),
                Apellido = reader["Apellido"].ToString(),
                CorreoElectronico = reader["CorreoElectronico"].ToString(),
                Telefono = reader["Telefono"] == DBNull.Value ? null : reader["Telefono"].ToString(),
                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"])
            };
        }
    }
}
