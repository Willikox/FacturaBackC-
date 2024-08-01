using GestionFacturas.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionFacturas.Contollers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturaController : ControllerBase
    {
        private static List<Factura> facturas = new List<Factura>(); 

        [HttpGet]
        public ActionResult<IEnumerable<Factura>> Get()
        {
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public ActionResult<Factura> Get(int id)
        {
            var factura = facturas.FirstOrDefault(f => f.Id == id);
            if (factura == null)
            {
                return NotFound();
            } 
            return Ok(factura);
        }

        [HttpPost]
        public ActionResult<Factura> Post(Factura factura)
        {
            factura.Id = facturas.Count + 1;
            factura.Total = factura.Detalles.Sum(d => d.Total);
            facturas.Add(factura);
            return CreatedAtAction(nameof(Get), new { id = factura.Id}, factura);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Factura facturaActializada)
        {
            var factura = facturas.FirstOrDefault(f => f.Id == id);
            if (factura == null)
            {
                return NotFound();
            }
            factura.Cliente = facturaActializada.Cliente;
            factura.Fecha = facturaActializada.Fecha;
            factura.Detalles = facturaActializada.Detalles;
            factura.Total = factura.Detalles.Sum(d => d.Total);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var factura = facturas.FirstOrDefault(f => f.Id == id);
            if (factura == null)
            {
                return NotFound();
            }
            facturas.Remove(factura);
            return NoContent();
        }
    }
}