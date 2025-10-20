using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaseAuto
{   
    internal class Auto
    {
        public string Marca { get; set; }
        public string Modelo {  get; set; }
        public int Año { get; set; }
        public Auto(string marca, string modelo, int año) {
            Marca = marca;
            Modelo = modelo;
            Año = año;
        }

        public void MostrarInfo()
        {
            Console.WriteLine($"Marca: {Marca}\nModelo: {Modelo} \nAño: {Año}");
        }
    }
    
}
