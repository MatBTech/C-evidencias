using System;
using System.Collections.Generic;

namespace sistemaEscolar.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Profesor { get; set; }

    public virtual ICollection<Matricula> Matriculas { get; set; } = new List<Matricula>();
}
