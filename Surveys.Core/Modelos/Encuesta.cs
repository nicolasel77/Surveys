using System;

namespace Surveys.Core.Clases
{
    public class Encuesta
    {
        public string Nombre { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Equipo_Favorito { get; set; }

        public override string ToString()
        {
            return $"{Nombre} | {Fecha_Nacimiento:dd/MM/yyy} | {Equipo_Favorito}";
        }
    }
}