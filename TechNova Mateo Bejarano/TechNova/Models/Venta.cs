using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Venta
{
    public int VentaId { get; set; }

    [Required(ErrorMessage = "El cliente es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "Seleccione un cliente válido.")]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime Fecha { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "El total no puede ser negativo.")]
    [DataType(DataType.Currency)]
    public decimal Total { get; set; }

    public virtual Cliente? Cliente { get; set; } = null!;


    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
