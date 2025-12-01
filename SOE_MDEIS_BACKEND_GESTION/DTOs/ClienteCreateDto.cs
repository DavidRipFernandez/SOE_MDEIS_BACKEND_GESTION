namespace SOE_MDEIS_BACKEND_GESTION.DTOs
{
    public class ClienteCreateDto
    {
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
    }
}
