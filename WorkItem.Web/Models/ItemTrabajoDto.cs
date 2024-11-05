namespace WorkItem.Web.Models
{
    public class ItemTrabajoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool Completado { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Relevancia { get; set; } // "Alta" o "Baja"
        public string? UsuarioAsignado { get; set; } = "";
    }
}
