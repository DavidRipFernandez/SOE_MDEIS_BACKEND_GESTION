namespace SOE_MDEIS_BACKEND_GESTION.DTOs
{
    public class ProductoDto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Categoria { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int StockActual { get; set; }
        public bool Activo { get; set; }
    }
}
