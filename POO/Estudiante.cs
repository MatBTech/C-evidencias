using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es
{
    internal class Estudiante
    {
        

        public string Nombre {  get; set; }
        public int Edad {  get; set; }
        public string Direccion {  get; set; }

        public Estudiante(string nombre, int edad, string direccion)
        {
            Nombre = nombre;
            Edad = edad;
            Direccion = direccion;
        }

        public void VerificarEdad()
        {
            if (Edad >= 18)
            {
                Console.WriteLine($"{Nombre}Eres mayor de edad");
            }
            else
            {
                Console.WriteLine($"{Nombre}Eres menor de edad");

            }
        }
    }
}
