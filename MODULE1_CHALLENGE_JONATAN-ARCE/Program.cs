﻿using System.ComponentModel.Design;
 
namespace MODULE1_CHALLENGE_JONATAN_ARCE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            principal();

        }
        //metodos
        //------------------------------------------------------------------------------------------
        public static void menu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("============================================");
            Console.WriteLine("|     Aplicación Convertidor de Moneda     |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("============================================");
            Console.WriteLine("");
            Console.WriteLine("============= Menú de Opciones =============");
            Console.WriteLine("      1. Convertir moneda");
            Console.WriteLine("      2. Listar");
            Console.WriteLine("      3. Editar");
            Console.WriteLine("      4. Buscar");
            Console.WriteLine("      5. Salir");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");
        }

        //------------------------------------------------------------------------------------------
        public static void principal()
        {
            int opcion = 0;
            bool salir = false;
            bool opContinue = false;
            menu();

            while (!salir)
            {
                Console.Write("* Ingrese su opción (1-5): ");
                if (int.TryParse(Console.ReadLine(), out opcion) == false)
                {
                    Console.WriteLine("¡Aviso! - Debe ingresar solo valores númericos ...");
                    salir = false;
                    Console.WriteLine("");
                }
                else
                {   if (opcion != 5)
                    { 
                        optionSelection(opcion);  //Evaluar opciones
                        opContinue = opcionSeguir(opcion);
                        if (opContinue == false)
                        {
                            menu();
                        }
                    }
                    else
                    {
                        salir = true;
                    }
                }
            }
            Console.WriteLine("\nFin del programa...");
            Console.ReadKey();
            Environment.Exit(0);
        }

        //------------------------------------------------------------------------------------------
        public static void optionSelection(int opcion)
        {
            const int CONVERTIR = 1;
            const int LISTAR = 2;
            const int MODIFICAR = 3;
            const int BUSCAR = 4;
            bool opContinue = false;

            var monedas = InicializarMonedas();

            Console.WriteLine($"Has seleccionado la Opción {opcion}" );
            switch (opcion)
            {
                case CONVERTIR:
                    {
                        currencyConvert(monedas);
                        break;
                    }
                case LISTAR:
                    {
                        currencyList(monedas);
                        break;
                    }
                case MODIFICAR:
                    {
                        Console.WriteLine("MODIFICAR");
                        break;
                    }
                case BUSCAR:
                    {
                        //Console.WriteLine("BUSCAR");
                        searchCurrency(monedas);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ingrese correctamente su Opción");
                        break;
                    }
            }

        }

        //------------------------------------------------------------------------------------------

        public static void currencyList(Dictionary<int, string[]> moneda)
        {
            string[] valorMoneda = new string[2];
            string cabecera;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--            LISTADO DE MONEDAS           --");
            Console.WriteLine("---------------------------------------------");

            Console.WriteLine("");
            Console.WriteLine("+---------------------------------------------+");
            cabecera =        " |Moneda      |Abreviatura|Tipo Cambio|Simbolo";
            Console.WriteLine(cabecera);
            Console.WriteLine("+---------------------------------------------+");
             
            foreach (var filas in moneda)
            {
                valorMoneda = filas.Value;
                foreach (string filaArray in filas.Value)
                {
                    Console.Write(" | " + filaArray.PadRight(10));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("\n");
            Console.WriteLine("Presione enter para retornar a las opciones ...");
            Console.ReadLine();

        }


        //------------------------------------------------------------------------------------------
        public static void currencyConvert(Dictionary<int, string[]> moneda)
        {
            //var monedas = InicializarMonedas();
            int monedaOrigen, monedaDestino;
            decimal importe, importeCalculado = 0;
            string[] valorMoneda = new string[2];

            Console.WriteLine("--------------------------");
            Console.WriteLine("--   CONVERTIR MONEDA   --");
            Console.WriteLine("--------------------------");

            Console.WriteLine("\nOpciones Moneda:");

            foreach (var filas in moneda)
            {
                Console.Write($"   {filas.Key}");
                valorMoneda = filas.Value;
                Console.Write(" - " + valorMoneda[0]);
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------");

            Console.Write(" Seleccione la moneda origen: ");
            if (int.TryParse(Console.ReadLine(), out monedaOrigen) == false)
            {
                Console.WriteLine("Debe ingresar solo valores númericos");
                return;
            }
            else
            {
                if ((moneda.ContainsKey(monedaOrigen)) == false)
                {
                    Console.WriteLine($"la Opcion de la moneda no es valida");
                    return;
                }
            }

            Console.Write($" Seleccione la moneda a convertir: ");
            if (int.TryParse(Console.ReadLine(), out monedaDestino) == false)
            {
                Console.WriteLine("Debe ingresar solo valores númericos");
                return;
            }
            else
            {
                if ((moneda.ContainsKey(monedaDestino)) == false)
                {
                    Console.WriteLine($"la Opcion de la moneda no es valida");
                    return;
                }
            }

            Console.Write($" ingrese el importe: ");
            if (decimal.TryParse(Console.ReadLine(), out importe) == false)
            {
                Console.WriteLine("Debe ingresar solo valores númericos: ");
                return;
            }


            Console.WriteLine("");
            Console.WriteLine($"la Conversión del importe de {importe} en {monedaOrigen} se convertira a  {monedaDestino} ");

            if (monedaOrigen == 1 && monedaDestino == 2)
            {
                importeCalculado = importe * 0.27m;
            }
            else if (monedaOrigen == 1 && monedaDestino == 3)
            {
                importeCalculado = importe * 0.27m * 0.92m;
            }
            Console.WriteLine($"Es {importeCalculado.ToString()}");
            Console.WriteLine("");

        }

        //------------------------------------------------------------------------------------------

        public static void searchCurrency(Dictionary<int, string[]> moneda)
        {
            string[] valorMoneda = new string[2];
            string cabecera, entrada;
            int indice = -1;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--              BUSCAR MONEDA              --");
            Console.WriteLine("---------------------------------------------");

            Console.Write("Digite la moneda para su busqueda: ");
            entrada = Console.ReadLine();

            foreach (var pos in moneda)
            {
                 //buscar palabra (por la moneda)
                  if  (pos.Value.Any(s => s.IndexOf(entrada, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    indice = pos.Key;
                    break;
                }
            }
            if (indice != -1)
            {
                Console.WriteLine($"Se encontró '{entrada}' en el elemento con clave {indice}");
            }
            else
            {
                Console.WriteLine($"No se encontró '{entrada}' en el diccionario");
                return;
            }

            Console.WriteLine("");
            Console.WriteLine("+---------------------------------------------+");
            cabecera = " |Moneda      |Abreviatura|Tipo Cambio|Simbolo";
            Console.WriteLine(cabecera);
            Console.WriteLine("+---------------------------------------------+");

            foreach (string filaArray in moneda[indice])
            {
                Console.Write(" | " + filaArray.PadRight(10));
            }
            Console.WriteLine("");

            Console.WriteLine("+---------------------------------------------+");
            Console.WriteLine("\n");
            //Console.WriteLine("Presione enter para retornar a las opciones ...");
            //Console.ReadLine();
        }

        //------------------------------------------------------------------------------------------
        public static Dictionary<int, string[]> InicializarMonedas()
        {
            Dictionary<int, string[]> monedas = new Dictionary<int, string[]>();

            monedas.Add(1, new string[] { "Soles", "PEN", "3.75", "S/." });
            monedas.Add(2, new string[] { "Dolar", "USD", "1.09", "$" });
            monedas.Add(3, new string[] { "Euro", "EUR", "0.92", "€" });

            return monedas;
        }

        //------------------------------------------------------------------------------------------
        static bool opcionSeguir(int opcion)
        {
            bool opContinue = false;
            string seguir = "S";

            if (opcion !=2)
            { 
                Console.Write("Desea ingresar otro? S/N : ");
                seguir = Console.ReadLine();
                if (seguir.ToUpper() == "S")
                {
                    opContinue = true;
                }
                else 
                {
                    opContinue = false;
                }
            }

            return opContinue;
        }


    }
}
