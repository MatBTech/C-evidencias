namespace CRUD_TRABAJO.Models
{
 public class Cliente
 {
  public int ClienteId { get; set; }
  public required string Nombre { get; set; }
  public required string Apellido { get; set; }
  public required string Direccion { get; set; }
  public required int Identificacion { get; set; }

  public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
 }
}
