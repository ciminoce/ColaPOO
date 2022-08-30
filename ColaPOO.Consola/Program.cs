using System;
using System.Collections.Generic;
using System.Threading;
using ColaPOO.Entidades;

namespace ColaPOO.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Queues!");
            var colaAtencion = new Queue<Persona>();
            var persona1 = new Persona() { Nombre = "Jon", Apellido = "Anderson", Telefono = "15416770" };
            var persona2 = new Persona() { Nombre = "Chris", Apellido = "Squire", Telefono = "15444444" };
            var persona3 = new Persona() { Nombre = "Alan", Apellido = "White", Telefono = "15467199" };
            colaAtencion.Enqueue(persona1);
            colaAtencion.Enqueue(persona2);
            colaAtencion.Enqueue(persona3);
            int contadorLugares = 0;
            foreach (var persona in colaAtencion)
            {
                contadorLugares++;
                Console.WriteLine($"Lugar {contadorLugares}: {persona.MostrarDatos()}");
            }
            
            var persona4 = new Persona() { Nombre = "Alan", Apellido = "White", Telefono = "15467199" };
            if (!colaAtencion.Contains(persona4))
            {
                colaAtencion.Enqueue(persona4);
            }
            else
            {
                Console.WriteLine($"{persona4.MostrarDatos()} ya existe en la cola de atención");
            }

            var personaSeleccionada = colaAtencion.Peek();
            Console.WriteLine($"{personaSeleccionada.MostrarDatos()}");
            do
            {
                Console.WriteLine($"Próxima persona a ser atendida:{colaAtencion.Peek().MostrarDatos()}");
                Thread.Sleep(3000);
                Console.WriteLine($"Atendiendo a {colaAtencion.Peek().MostrarDatos()}");
                colaAtencion.Dequeue();
            } while (colaAtencion.Count>0);
        }
    }
}
