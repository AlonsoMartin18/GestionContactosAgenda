﻿namespace Entity
{
    public class Contacto
    {
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; } // Opcional
        public DateTime FechaNacimiento { get; set; }
    }
}
