using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Gato
{
    class CAhorcado
    {
        private char[,] pantalla  = new char[6,5];

        public char validaChar(string mensaje)
        {
            char regresar;
            bool valor;

            do
            {
                Console.Write(mensaje);
                valor = char.TryParse(Console.ReadLine().ToLower().Trim(), out regresar);
            } while (!valor||regresar==' ');

            return regresar;
        }
        public void Iniciar()
        {

            string palabraEncontrar;//palabra generada 
            char ingresado;//letra ingresada por el usuario 
            char[] palabraEspacios;//muestra en pantalla las palabras ingresadas correctamnete 
            bool salir=false;//sirve para salir 

            int letraCorrectas, intentos;//contadores letras Correctas 


            do
            {
                palabraEncontrar = palabra();//seleccionamos una palabra para que el usuario la encuentre
                ingresado = ' ';//sera el caracteres que ingresa el usuaio 
                palabraEspacios = new char[palabraEncontrar.Length];//seran las barras del juego _ _ _ _ _ _ _
                for (int i = 0; i < palabraEspacios.Length; i++) palabraEspacios[i] = '_';///ponemos todoas las barritas 

                letraCorrectas = 0;//contador de letra correcta
                intentos = 0;//contador de intentos

                do
                {
                    DibujarTablero(intentos);//dibujamos al ahorcado
                    espacios(palabraEspacios);//dibujamos las barras_ _ _ _ _ _ _
                    mensajeIntentos(intentos);
                    do
                    {
                        ingresado = validaChar("Inserta una letra: ");//comprobamos el caracterer ingresado y lo validamos
                        
                    } while (ingresado==' '||!char.IsLetter(ingresado));//si es vacio repetimos 

                    int aux = 0;//nos ayudara para procesos
                    intentos++;//aumentamos en 1 los intentos
                    for (int i = 0; i < palabraEncontrar.Length; i++)//recorramos hasta la longitud de la palabra seleccionada
                    {
                        if (ingresado == palabraEspacios[i])//si ya existe una tecla ingresado le hacemos saber que ya ha ingresado ese caracter
                        {
                            aux++;//aumentamos en 1 
                            if (aux == 1)
                            {
                                Console.WriteLine("letra: {0} anteriormente ingresada", ingresado);//mostramos un mensaje en caso de que caracteres ya ha sido puesto anteriormente
                                Console.WriteLine("Presione una letra para continuar");
                                Console.ReadKey();
                                break;
                            }
                        }
                        else
                        {
                            if (ingresado == palabraEncontrar[i])//si el caracter ingresado es igual a letra de la palabra seleccionada 
                                //le aginamos el indice ejemplo
                                //_a_ _ _
                            {
                                if (i == 0)
                                {
                                    //palabraEspacios[i] = char.Parse(ingresado.ToString().ToUpper());
                                    palabraEspacios[i] = char.ToUpper(ingresado);
                                    
                                    letraCorrectas++;//aumnetamos la letra correcta para verificar si ya completo la palabra
                                    aux++;
                                }
                                else
                                {
                                    palabraEspacios[i] = ingresado;
                                    letraCorrectas++;//aumnetamos la letra correcta para verificar si ya completo la palabra
                                    aux++;
                                }
                            }
                        }
                    }
                    if (aux > 0)
                    {
                        intentos--;
                    }
                    Console.Clear();
                } while (intentos < 9&&letraCorrectas<palabraEncontrar.Length);
                
                if (letraCorrectas == palabraEncontrar.Length)
                {
                    DibujarTablero(intentos);
                    espacios(palabraEspacios);
                    Console.WriteLine("Has ganado la palabra es: {0}",palabraEncontrar.Substring(0,1).ToUpper()+palabraEncontrar.Substring(1));
                    salir = Nuevamente();
                    if (!salir)
                    {
                        Console.Clear();
                    }
                }
                else
                {
                    DibujarTablero(intentos);
                    espacios(palabraEspacios);
                    Console.WriteLine("Has perdido la palabra era: {0}", palabraEncontrar.Substring(0, 1).ToUpper() + palabraEncontrar.Substring(1));
                    salir = Nuevamente();
                    if (!salir)
                    {
                        Console.Clear();
                    }
                }
            } while (salir == false);
        }
        public void mensajeIntentos(int intentos)
        {
            int intent = 9 - intentos;
            if (intent > 5)
            {
                Console.WriteLine("Te quedan {0} intentos ", 9 - intentos);
            }

            if (intent > 3&&intent<=5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Te quedan {0} intentos ", 9 - intentos);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
            
            if (intent >0&&intent<=3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Te quedan {0} intentos ", 9 - intentos);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            
        }
        public bool Nuevamente()
        {
            string palabra="";
            do
            {
                Console.Write("\nDeseas jugar de nuevo (S/N): ");
                palabra = Console.ReadLine().Trim().ToUpper();
            } while (palabra != "S" && palabra != "N");

            if (palabra == "S")
            {
                return !true;
            }
            else{
                return !false;
            }
        }
        private void espacios(char [] palabra)
        {
            for(int i = 0; i < palabra.Length; i++)
            {
                Console.Write("{0} ", palabra[i]);
            }
            Console.WriteLine();
        }
        private void DibujarTablero(int intentos)
        {
            
            if (intentos == 0)
            {
                pantalla[2, 3] = ' ';
                pantalla[3, 3] = ' ';
                pantalla[3, 2] = ' ';
                pantalla[3, 4] = ' ';
                pantalla[4, 3] = ' ';
                pantalla[5, 2] = ' ';
                pantalla[5, 4] = ' ';
            }
            if (intentos >= 1) pantalla[2, 3] = 'O';
            if (intentos >= 2) pantalla[3, 3] = '|';
            if (intentos >= 3) pantalla[3, 2] = '/';
            if (intentos >= 4) pantalla[3, 4] = '\\';
            if (intentos >= 5) pantalla[4, 3] = '|';
            if (intentos >= 6) pantalla[5, 2] = '/';
            if (intentos >= 7) pantalla[5, 4] = 'l';

            for (int i = 0; i < 6; i++)pantalla[i, 0] = '|';
            for(int i = 0; i < 5; i++)pantalla[0, i] = '_';
            pantalla[1, 3] = '|';
            
            for(int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0}", pantalla[i, j]);
                }
                Console.WriteLine();
            }


            
        }

        private string palabra()
        {
            Random rdn = new Random();

            string[] palabras = new string[] {"mesa","puerta","casa","peluche","sillon","gato","perro","oso","telefono","calabaza","comida","fruta","galleta","arroz","bosque","conejo"};

            string palabra = palabras[rdn.Next(palabras.Length-1)];

            return palabra;
            //return "calabazacomo estas bien gracias y tu";
        }
    }
}
