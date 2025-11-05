using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pro
{
    internal class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public float Precio {  get; set; }
        public Producto (int id, string nombre, float precio)
        {
            ID = id;
            Nombre = nombre;
            Precio = precio;
        }

        

                
    }

    internal class ProductoCrud
    {
        public List<Producto> productos = new List<Producto>();
        public int siguienteId = 1;
        public void CrearProducto()
        {
            

            Console.WriteLine("ingresa el nombre de tu producto");
            string nompreProdcuto = Console.ReadLine();
            Console.WriteLine("ingresa el precio de tu producto");
            float precioProdcuto = float.Parse(Console.ReadLine());
            Producto producto = new Producto(siguienteId++, nompreProdcuto, precioProdcuto);
            productos.Add(producto);
        }

        public void ActualizarProducto(int idProducto)
        {
            
            Producto producto = productos.Find(p => p.ID == idProducto);
            if (producto!=null)
            {
                Console.WriteLine($"vas a actualizar el siguiente producto: id: {producto.ID} \n nombre: {producto.Nombre} \n precio: {producto.Precio}");
                Console.WriteLine("ingrese el nuevo nombre");
                string nombreNuevo = Console.ReadLine();
                Console.WriteLine("ingrese el nuevo precio");
                float precioNuevo = float.Parse(Console.ReadLine()) ;

                producto.Nombre = nombreNuevo;
                producto.Precio = precioNuevo;

            }
            else
            {
                Console.WriteLine("no se ha encontrado producto"); 
            }
        }

        public void EliminarProducto(int idProducto)
        {

            Producto producto = productos.Find(p => p.ID == idProducto);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("producto eliminado con exito");
            }
            else
            {
                Console.WriteLine("no se ha encontrado producto");
            }
        }

        public void MostrarProductos()
        {
            foreach (var producto in productos)
            {
                Console.WriteLine($"ID: {producto.ID}nombre: {producto.Nombre} precio: {producto.Precio}");
            }

        }
    }

}
