using System;

Console.WriteLine("\t \t \t -------------");
Console.WriteLine("\t \t \t BATALLA NAVAL");
Console.WriteLine("\t \t \t -------------");
Console.WriteLine("");
Console.WriteLine("");
Console.Write("\t \t \tIngresa tu nombre: ");
String nombre;
nombre = Console.ReadLine();
//Menu de selección de dificultad.
Console.Clear();
int dificultad = 0;
Console.WriteLine("\t \t \t -------------");
Console.WriteLine("\t \t \t BATALLA NAVAL");
Console.WriteLine("\t \t \t -------------");
Console.WriteLine("Bienvenido " + nombre);
Console.WriteLine("Selecciona la dificultad:");
Console.WriteLine("1.Fácil (Tablero 5x5, 4 barcos, 15 intentos). \n2.Medio (Tablero 8x8, 8 barcos, 18 intentos). \n3.Dificil (Tablero 10x10, 10 barcos, 25 intentos).");
dificultad = int.Parse(Console.ReadLine());

try 
{

    if (dificultad > 3)
    {
        Console.WriteLine("Ingrese una opción válida.");
        Environment.Exit(0);
    }

}
catch (FormatException)
{
    Console.WriteLine("Ingresa un número válido.");
}


switch (dificultad)
{
    case 1:
        int[,] tablero = new int[5, 5];
        void paso1_crear_tablero() //Creación del Tablero
        {
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {
                    tablero[f, c] = 0;
                }
            }
        }
        void paso2_colocar_barcos()
        {
            //Generar los barcos aleatoriamente
            var barcos = new List<(int, int)>();
            var random = new Random();
            while (barcos.Count < 4)
            {
                int fila = random.Next(0, 5);
                int columna = random.Next(0, 5);
                if (!barcos.Contains((fila, columna)))
                {
                    barcos.Add((fila, columna));
                    tablero[fila, columna] = 1;
                }
            }


        }

        void paso3_imprimir_tablero()
        {
            string caracter_a_imprimir = "";
            for (int f = 0; f < tablero.GetLength(0); f++)
            {
                for (int c = 0; c < tablero.GetLength(1); c++)
                {

                    switch (tablero[f, c]) //Imprimir carácteres en el tablero
                    {
                        case 0:
                            caracter_a_imprimir = "-";
                            break;
                        case 1:
                            caracter_a_imprimir = "-";
                            break;
                        case -1:
                            caracter_a_imprimir = "2";
                            break;
                        case -2:
                            caracter_a_imprimir = "1";
                            break;
                        default:
                            caracter_a_imprimir = "-";
                            break;
                    }
                    Console.Write(caracter_a_imprimir + "");
                }
                Console.WriteLine();
            }
        }

        void paso4_ingreso_coordenadas()
        {
            int fila, columna, intentos = 0;
            const int max_intentos = 15; //El máximo de intentos que tiene el usuario.
            Console.Clear();
            int barcosrestantes = 4;


            do
            {
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("\t \t \t BATALLA NAVAL");
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("Dificultad: Fácil.");
                Console.WriteLine("Ingrese una coordenada:");
                Console.WriteLine("");
                Console.Write("Ingresa la fila:");
                fila = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de filas del tablero.
                {

                    if (fila > 4)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 4");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }

                Console.Write("Ingresa la columna:");
                columna = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de columnas del tablero.
                {

                    if (columna > 4)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 4");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }




                if (tablero[fila, columna] == 1) //Condicional para verificar si el usuario le dió a un barco o no.
                {
                    Console.Beep();
                    tablero[fila, columna] = -1;
                    Console.WriteLine("");
                    Console.WriteLine("¡Le diste a un barco!");
                    barcosrestantes--;
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }
                else
                {
                    tablero[fila, columna] = -2;
                    Console.WriteLine("");
                    Console.WriteLine("No le diste a ningún barco, intenta de nuevo");
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }

                Console.Clear();
                paso3_imprimir_tablero();

                intentos++; //La suma de cada intento realizado por el usuario.
                Console.WriteLine("Intentos Realizados (Máx = 15): " + intentos);
                Console.WriteLine("");

                if (intentos == max_intentos) //Estructura para terminar el juego cuando los intentos se acaben.
                {
                    Console.Clear();
                    Console.WriteLine("¡Ups, se te acabaron los intentos!");
                    Environment.Exit(0);
                }

                if (barcosrestantes == 0) //Estructura para terminar el juego cuando se hayan hundido todos los barcos.
                {
                    Console.Clear();
                    Console.Write($"¡Felicidades {nombre}, has hundido todos los barcos!");
                    Console.Write("\t \t \t Intentos realizados para terminar el juego: " + intentos);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(698, 350);
                    Console.Beep(523, 150);
                    Console.Beep(415, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000); //Marcha imperial, Star Wars.
                    Environment.Exit(0);
                }
            } while (true);

        }


        paso1_crear_tablero();
        paso2_colocar_barcos();
        paso3_imprimir_tablero();
        paso4_ingreso_coordenadas();
        break; //Final de la dificultad fácil.

    case 2:
        int[,] tablero_ = new int[8, 8];
        void paso1__crear_tablero() //Creación del Tablero
        {
            for (int f = 0; f < tablero_.GetLength(0); f++)
            {
                for (int c = 0; c < tablero_.GetLength(1); c++)
                {
                    tablero_[f, c] = 0;
                }
            }
        }
        void paso2__colocar_barcos()
        {
            //Generar los barcos aleatoriamente
            var barcos = new List<(int, int)>();
            var random = new Random();
            while (barcos.Count < 8)
            {
                int fila = random.Next(0, 8);
                int columna = random.Next(0, 8);
                if (!barcos.Contains((fila, columna)))
                {
                    barcos.Add((fila, columna));
                    tablero_[fila, columna] = 1;
                }
            }

        }

        void paso3__imprimir_tablero()
        {
            string caracter_a_imprimir = "";
            for (int f = 0; f < tablero_.GetLength(0); f++)
            {
                for (int c = 0; c < tablero_.GetLength(1); c++)
                {

                    switch (tablero_[f, c]) //Imprimir carácteres en el tablero
                    {
                        case 0:
                            caracter_a_imprimir = "-";
                            break;
                        case 1:
                            caracter_a_imprimir = "-";
                            break;
                        case -1:
                            caracter_a_imprimir = "2";
                            break;
                        case -2:
                            caracter_a_imprimir = "1";
                            break;
                        default:
                            caracter_a_imprimir = "-";
                            break;
                    }
                    Console.Write(caracter_a_imprimir + "");
                }
                Console.WriteLine();
            }
        }

        void paso4__ingreso_coordenadas()
        {
            int fila, columna, intentos = 0;
            const int max_intentos = 18; //El máximo de intentos que tiene el usuario.
            Console.Clear();
            int barcosrestantes = 8;


            do
            {
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("\t \t \t BATALLA NAVAL");
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("Dificultad: Media.");
                Console.WriteLine("Ingrese una coordenada:");
                Console.WriteLine("");
                Console.Write("Ingresa la fila:");
                fila = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de filas del tablero.
                {

                    if (fila > 8)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 8");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }

                Console.Write("Ingresa la columna:");
                columna = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de columnas del tablero.
                {

                    if (columna > 8)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 8");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }




                if (tablero_[fila, columna] == 1) //Condicional para verificar si el usuario le dió a un barco o no.
                {
                    Console.Beep();
                    tablero_[fila, columna] = -1;
                    Console.WriteLine("");
                    Console.WriteLine("¡Le diste a un barco!");
                    barcosrestantes--;
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }
                else
                {
                    tablero_[fila, columna] = -2;
                    Console.WriteLine("");
                    Console.WriteLine("No le diste a ningún barco, intenta de nuevo");
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }
                Console.Clear();
                paso3__imprimir_tablero();

                intentos++; //La suma de cada intento realizado por el usuario.
                Console.WriteLine("Intentos Realizados (Máx = 18): " + intentos);
                Console.WriteLine("");

                if (intentos == max_intentos) //Estructura para terminar el juego cuando los intentos se acaben.
                {
                    Console.Clear();
                    Console.WriteLine("¡Ups, se te acabaron los intentos!");
                    Environment.Exit(0);
                }

                if (barcosrestantes == 0) //Estructura para terminar el juego cuando se hayan hundido todos los barcos.
                {
                    Console.Clear();
                    Console.Write($"¡Felicidades {nombre}, has hundido todos los barcos!");
                    Console.Write("\t \t \t Intentos realizados para terminar el juego: " + intentos);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(698, 350);
                    Console.Beep(523, 150);
                    Console.Beep(415, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000); //Marcha imperial, Star Wars.
                    Environment.Exit(0);
                }
            } while (true);

        }

        paso1__crear_tablero();
        paso2__colocar_barcos();
        paso3__imprimir_tablero();
        paso4__ingreso_coordenadas();
        break; //Final de la dificultad media.

    case 3:
        int[,] tablero__ = new int[10, 10];
        void paso1___crear_tablero() //Creación del Tablero
        {
            for (int f = 0; f < tablero__.GetLength(0); f++)
            {
                for (int c = 0; c < tablero__.GetLength(1); c++)
                {
                    tablero__[f, c] = 0;
                }
            }
        }
        void paso2___colocar_barcos()
        {
            //Generar los barcos aleatoriamente
            var barcos = new List<(int, int)>();
            var random = new Random();
            while (barcos.Count < 10)
            {
                int fila = random.Next(0, 10);
                int columna = random.Next(0, 10);
                if (!barcos.Contains((fila, columna)))
                {
                    barcos.Add((fila, columna));
                    tablero__[fila, columna] = 1;
                }
            }

        }

        void paso3___imprimir_tablero()
        {
            string caracter_a_imprimir = "";
            for (int f = 0; f < tablero__.GetLength(0); f++)
            {
                for (int c = 0; c < tablero__.GetLength(1); c++)
                {

                    switch (tablero__[f, c]) //Imprimir carácteres en el tablero
                    {
                        case 0:
                            caracter_a_imprimir = "-";
                            break;
                        case 1:
                            caracter_a_imprimir = "-";
                            break;
                        case -1:
                            caracter_a_imprimir = "2";
                            break;
                        case -2:
                            caracter_a_imprimir = "2";
                            break;
                        default:
                            caracter_a_imprimir = "-";
                            break;
                    }
                    Console.Write(caracter_a_imprimir + "");
                }
                Console.WriteLine();
            }
        }

        void paso4___ingreso_coordenadas()
        {
            int fila, columna, intentos = 0;
            const int max_intentos = 25; //El máximo de intentos que tiene el usuario.
            Console.Clear();
            int barcosrestantes = 10;


            do
            {
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("\t \t \t BATALLA NAVAL");
                Console.WriteLine("\t \t \t -------------");
                Console.WriteLine("Dificultad: Dificil.");
                Console.WriteLine("Ingrese una coordenada:");
                Console.WriteLine("");
                Console.Write("Ingresa la fila:");
                fila = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de filas del tablero.
                {

                    if (fila > 10)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 10");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }

                Console.Write("Ingresa la columna:");
                columna = Convert.ToInt32(Console.ReadLine());

                try //Función para que el usuario no sobrepase el límite de columnas del tablero.
                {

                    if (columna > 10)
                    {
                        Console.WriteLine("No puedes ingresar un número mayor a 10");
                        Environment.Exit(0);
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingresa un número válido.");
                }




                if (tablero__[fila, columna] == 1) //Condicional para verificar si el usuario le dió a un barco o no.
                {
                    Console.Beep();
                    tablero__[fila, columna] = -1;
                    Console.WriteLine("");
                    Console.WriteLine("¡Le diste a un barco!");
                    barcosrestantes--;
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }
                else
                {
                    tablero__[fila, columna] = -2;
                    Console.WriteLine("");
                    Console.WriteLine("No le diste a ningún barco, intenta de nuevo");
                    Console.WriteLine("Barcos restantes: " + barcosrestantes);
                    Console.WriteLine("Presiona enter para continuar.");
                    Console.ReadLine();
                }

                Console.Clear();
                paso3___imprimir_tablero();

                intentos++; //La suma de cada intento realizado por el usuario.
                Console.WriteLine("Intentos Realizados (Máx = 25): " + intentos);
                Console.WriteLine("");

                if (intentos == max_intentos) //Estructura para terminar el juego cuando los intentos se acaben.
                {
                    Console.Clear();
                    Console.WriteLine("¡Ups, se te acabaron los intentos!");
                    Environment.Exit(0);
                }

                if (barcosrestantes == 0) //Estructura para terminar el juego cuando se hayan hundido todos los barcos.
                {
                    Console.Clear();
                    Console.Write($"¡Felicidades {nombre}, has hundido todos los barcos!");
                    Console.Write("\t \t \t Intentos realizados para terminar el juego: " + intentos);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(659, 500);
                    Console.Beep(698, 350);
                    Console.Beep(523, 150);
                    Console.Beep(415, 500);
                    Console.Beep(349, 350);
                    Console.Beep(523, 150);
                    Console.Beep(440, 1000); //Marcha imperial, Star Wars.
                    Environment.Exit(0);
                }
            } while (true);

        }

        paso1___crear_tablero();
        paso2___colocar_barcos();
        paso3___imprimir_tablero();
        paso4___ingreso_coordenadas();   
        break;//Final de la dificultad dificil.

    default:
        Console.WriteLine("Seleccione una opción válida");
        break;
}


