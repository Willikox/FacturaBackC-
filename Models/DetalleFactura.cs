namespace GestionFacturas.Models
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal Total => Cantidad * precioUnitario;
    }
}