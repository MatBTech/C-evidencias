using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechNova.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string NombreCompleto { get; set; } = null!;

    [Required(ErrorMessage = "El correo es obligatorio.")]
    [EmailAddress(ErrorMessage = "El correo no tiene un formato válido.")]
    public string Correo { get; set; } = null!;

    [StringLength(50, ErrorMessage = "La dirección no puede tener más de 50 caracteres.")]
    public string? Direccion { get; set; }

    [Phone(ErrorMessage = "El teléfono no tiene un formato válido.")]
    public string? Telefono { get; set; }

    public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
}
