using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models
{
    public class VentaCreateViewModel
    {
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente válido.")]
        public int ClienteId { get; set; }

        public List<VentaItemViewModel> Items { get; set; } = new();
        public List<Cliente> Clientes { get; set; } = new();
        public List<Producto> Productos { get; set; } = new();
    }

    public class VentaItemViewModel
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un producto válido.")]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio no puede ser negativo.")]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El subtotal no puede ser negativo.")]
        public decimal Subtotal { get; set; }
    }
}
