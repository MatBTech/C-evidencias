using System;
using System.Collections.Generic;

namespace sistemaEscolar.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? Documento { get; set; }

    public string? TipoDocumento { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
