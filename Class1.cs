using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Gato
{
    class CGato
    {
        private int [,] tablero = new int[3, 3];
        private char[] simbolos = { ' ', 'X', 'O' };
        public void inicar()
        {
            int jugador = 1;
            bool terminado = false;
            bool ganador = false;
            do
            {
                jugador = 1;
                DibujarTablero();
                PreguntarPosicion(jugador);
                ganador=comprobarGanador();
                if (ganador)
                {
                    Console.Clear();
                    DibujarTablero();
                    Console.WriteLine("!!!!El jugador 1 ha ganada¡¡¡¡");
                }
                else
                {
                    ganador = comprobarEmpate();
                    if (ganador)
                    {
                        Console.Clear();
                        DibujarTablero();
                        Console.WriteLine("\t!!!!Esto es un empate¡¡¡¡¡¡");
                        
                        
                    }
                    else
                    {
                        jugador = 2;
                        Console.Clear();
                        DibujarTablero();
                        PreguntarPosicion(jugador);
                        ganador = comprobarGanador();
                        if (ganador)
                        {
                            Console.Clear();
                            DibujarTablero();
                            Console.WriteLine("!!!!Ha ganado el jugador 2¡¡¡¡");
                            ganador = true;
                        }
                    }
                }
                if (ganador)
                {
                    string jugarM;
                    do
                    {
                        Console.Write("Quieres jugar de nuevo (S/N): ");
                        jugarM = Console.ReadLine().Trim().ToUpper();

                    } while (jugarM.Length < 1 || jugarM.Length > 2);
                    if (jugarM == "S")
                    {
                        ganador = false;
                        Reinciar();
                    }
                }
                Console.Clear();
            } while (ganador != true);
        }
        private void Reinciar()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    tablero[i, j] = 0;
                }
            }
        }
        private void DibujarTablero()
        {
            int i;//filas
            int j;//columnas
            Console.WriteLine();
            Console.WriteLine("-------------");
            for(i = 0; i < 3; i++)
            {
                Console.Write("|");
                for (j = 0; j < 3; j++)
                {
                    Console.Write(" {0} |", simbolos[tablero[i, j]]);
                    
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }
        private void PreguntarPosicion(int jugador)
        {
            int i;//lo utlicamos para las filas
            int j;//lo tilizammos para las columnas
      
            do
            {
                Console.WriteLine("Turno del jugador {0}", jugador);
                do
                {
                    i = validaInt("Dame las fila: ");
                    
                } while (i < 1 || i > 3);
                do
                {
                   
                    j = validaInt("Dame la columna: ");
                } while (j < 1 || j > 3);

                if (tablero[i - 1, j - 1] != 0)
                {
                    Console.WriteLine("\t\nCasilla ocupada");
                }
            } while (tablero[i-1,j-1]!=0);

            tablero[i - 1, j - 1] = jugador;

        }

        private bool comprobarGanador()
        {
            
            bool ganador = false;
            int i = 0;//filas
            

            //comprobamos las filas
            for(i = 0; i < 3; i++)
            {
                if (tablero[0, i] == tablero[1, i] && tablero[0, i] == tablero[2, i] && tablero[0, i] != 0)
                {
                    ganador = true;
                }
            }


            
            //comprobamos las columnas
            for (i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == tablero[i, 1] && tablero[i, 0] == tablero[i, 2] && tablero[i, 0] != 0)
                {
                    ganador = true;
                }
            }

            //comprobamos la diagonal \

            if (tablero[0, 0] == tablero[1, 1] && tablero[0, 0] == tablero[2, 2] && tablero[0, 0] != 0)
            {
                ganador = true;
            }
            //comprobamos la diaganoal /
            if (tablero[0, 2] == tablero[1, 1] && tablero[0, 2] == tablero[2, 0] && tablero[0, 2] != 0)
            {
                ganador = true;
            }
           
            return ganador;
        }
        private bool comprobarEmpate()
        {
            bool espacio=false;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == 0)
                    {
                        espacio = true;
                    }
                }
            }

            return !espacio;
        }

        private int validaInt(string mensaje)
        {
            int numFinal;
            bool valor;
            do
            {
                Console.Write(mensaje);
                valor = int.TryParse(Console.ReadLine(), out numFinal);
            } while (!valor);

            return numFinal;
        }
    }
}
