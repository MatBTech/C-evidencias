using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
    [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [StringLength(500, ErrorMessage = "La descripción no puede tener más de 500 caracteres.")]
    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "El precio es obligatorio.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0.")]
    [DataType(DataType.Currency)]
    public decimal PrecioUnitario { get; set; }

    [Required(ErrorMessage = "El stock es obligatorio.")]
    [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo.")]
    public int Stock { get; set; }

    [Required(ErrorMessage = "El código es obligatorio.")]
    [StringLength(50, ErrorMessage = "El código no puede tener más de 50 caracteres.")]
    public string Codigo { get; set; } = null!;

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
