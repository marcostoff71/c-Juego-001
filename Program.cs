using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Gato
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\tBienvenido");
                Console.WriteLine("1. juego del ahorcado");
                Console.WriteLine("2. juego de  Tic Tac Toe");
                Console.WriteLine("3. Sair");
                

                do
                {
                    
                    opcion = validaInt("Selecciona un juego: ");
                } while (opcion < 1 || opcion > 3);
                Console.ForegroundColor = ConsoleColor.Gray;
                switch (opcion )
                {
                    case 1:
                        Console.Clear();
                        CAhorcado juego2 = new CAhorcado();
                        juego2.Iniciar();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        CGato juego1 = new CGato();
                        juego1.inicar();
                        Console.Clear();
                        break;

                }

            } while (opcion != 3);
            
            //CGato juego1 = new CGato();
            //juego1.inicar();

            

        }
        static int validaInt(string mensaje)
        {
            bool valor;
            int numfinal;
            do
            {
                Console.Write(mensaje);
                valor = int.TryParse(Console.ReadLine(), out numfinal);
            } while (!valor);
            return numfinal;
        }
    }
}
