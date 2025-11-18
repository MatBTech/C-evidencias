using System;
using System.Collections.Generic;

namespace sistemaEscolar.Models;

public partial class Matricula
{
    public int Id { get; set; }

    public int Estudiante { get; set; }

    public int Curso { get; set; }

    public virtual Curso ? CursoNavigation { get; set; }

    public virtual Estudiante ? EstudianteNavigation { get; set; } 
}
