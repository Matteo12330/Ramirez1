namespace Ramirez1.Models
{
    public class Ramirez
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public required string CorreoElectronico { get; set; }
        public bool EsEstudiante { get; set; }
        public int CarreraId { get; set; }
        public Carrera? Carrera { get; set; }
    }
}
