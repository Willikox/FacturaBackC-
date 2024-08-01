namespace GestionFacturas.Models{
    public class Factura {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleFactura> Detalles { get; set;}
        public decimal Total { get; set;}

        public Factura()
        {
            Detalles = new List<DetalleFactura>();
        }
        
    }
}