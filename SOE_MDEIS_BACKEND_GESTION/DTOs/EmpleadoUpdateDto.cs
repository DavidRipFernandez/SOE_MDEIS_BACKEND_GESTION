namespace SOE_MDEIS_BACKEND_GESTION.DTOs
{
    public class EmpleadoUpdateDto
    {
        public string TipoDocumento { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Cargo { get; set; } = null!;
        public string? Email { get; set; }
        public string? Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }
        public decimal SalarioMensual { get; set; }
        public bool Activo { get; set; }
    }
}
