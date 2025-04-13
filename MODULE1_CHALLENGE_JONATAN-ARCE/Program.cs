using System.ComponentModel.Design;
 
namespace MODULE1_CHALLENGE_JONATAN_ARCE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Iniciando ..");
            Principal();

        }

        const int CONVERTIR = 1;
        const int LISTAR = 2;
        const int MODIFICAR = 3;
        const int BUSCAR = 4;
        static bool continuarOpcion = false;

        //metodos
        //------------------------------------------------------------------------------------------


        public static void ViewMenu()
        {
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("\n");
            Console.WriteLine("============================================");
            Console.WriteLine("|     Aplicación Convertidor de Moneda     |");
            Console.WriteLine("|                                          |");
            Console.WriteLine("============================================");
            Console.WriteLine("                                            ");
            Console.WriteLine("============= Menú de Opciones =============");
            Console.WriteLine("      1. Convertir moneda                   ");
            Console.WriteLine("      2. Listar                             ");
            Console.WriteLine("      3. Editar                             ");
            Console.WriteLine("      4. Buscar                             ");
            Console.WriteLine("      5. Salir                              ");
            Console.WriteLine("--------------------------------------------");
            //Console.ResetColor();
        }



        //------------------------------------------------------------------------------------------
        public static void Principal()
        {
            int opcion = 0;
            bool salir = false;
            bool opContinue = false, opSeguir = false;

            var monedas = InicializarMonedas();
            //ViewMenu();

            while (!salir)
            {
                ViewMenu();
                Console.Write("\n* Ingrese su opción (1-5): ");
                if (int.TryParse(Console.ReadLine(), out opcion) == false)
                {
                    Console.WriteLine("¡Aviso! - Debe ingresar solo valores númericos ...");
                    salir = false;
                    Console.WriteLine("");
                }
                else
                {

                    if (opcion != 5)
                    {
                        //while (opSeguir)
                        //{
                        OptionSelection(opcion, monedas);  //Evaluar opciones
                                                           //opContinue = OptionContinue(opcion);
                                                           //if (opContinue == false)
                                                           //{
                                                           //    Console.WriteLine("false N");
                                                           //    //ViewMenu();
                                                           //}
                                                           //else
                                                           //{
                                                           //    //probando nuevo reingreso
                                                           //    opSeguir = true;
                                                           //    Console.WriteLine("true");
                                                           //}


                        //}
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
        public static void OptionSelection(int opcion, Dictionary<int, string[]> moneda)
        {


            Console.WriteLine($" Has seleccionado la Opción {opcion} del Menú.");
            Console.WriteLine("");
            switch (opcion)
            {
                case CONVERTIR:
                    {
                        CurrencyConvert(moneda);
                        break;
                    }
                case LISTAR:
                    {
                        CurrencyList(moneda);
                        break;
                    }
                case MODIFICAR:
                    {
                        UpdateCurrency(moneda);
                        break;
                    }
                case BUSCAR:
                    {
                        SearchCurrency(moneda);
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

        public static void CurrencyList(Dictionary<int, string[]> moneda)
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--            LISTADO DE MONEDAS           --");
            Console.WriteLine("---------------------------------------------");

            PrintCurrency(moneda, 0); //imprimir todos

            Console.WriteLine("Presione enter para retornar a las opciones ...");
            Console.ReadLine();
        }


        //------------------------------------------------------------------------------------------
        public static void CurrencyConvert(Dictionary<int, string[]> moneda)
        {
            int monedaOrigen, monedaDestino;
            decimal importe = 0, importeCalculado = 0;
            string[] valorMoneda = new string[6];
            bool entradaValida = false;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--           CONVERSOR DE MONEDA           --");
            Console.WriteLine("---------------------------------------------");

            ListCurrencyOptions(moneda);

            Console.WriteLine("---------------------------------------------");
            monedaOrigen = NumericalValidationCurrency(moneda, "Origen", 0);
            monedaDestino = NumericalValidationCurrency(moneda, "Destino", monedaOrigen);

            while (!entradaValida)
            {
                Console.Write(" - Ingrese el Importe: ");
                if (decimal.TryParse(Console.ReadLine(), out importe) == false)
                {
                    Console.WriteLine("Debe ingresar solo valores númericos: ");
                    return;
                }
                else
                {
                    entradaValida = true;
                }
            }

            Console.WriteLine("");
            Console.WriteLine($"la Conversión de {moneda[monedaOrigen][0]} a {moneda[monedaDestino][0]} del importe {importe} ");

            switch (monedaOrigen)
            {
                case 1 when monedaDestino == 2:
                    //PEN_USD
                    //Console.WriteLine("PEN_USD");
                    importeCalculado = importe / Convert.ToDecimal(moneda[monedaOrigen][4]); ;
                    break;
                case 1 when monedaDestino == 3:
                    //PEN_EUR
                    //Console.WriteLine("PEN_EUR");
                    importeCalculado = importe / (Convert.ToDecimal(moneda[monedaOrigen][4]) * Convert.ToDecimal(moneda[2][6]));
                    break;
                case 2 when monedaDestino == 1:
                    //USD_PEN
                    //Console.WriteLine("USD_PEN");
                    importeCalculado = importe * Convert.ToDecimal(moneda[monedaOrigen][4]); ;
                    break;
                case 2 when monedaDestino == 3:
                    //USD_EUR
                    //Console.WriteLine("USD_EUR");
                    importeCalculado = importe / Convert.ToDecimal(moneda[monedaOrigen][6]);
                    break;
                case 3 when monedaDestino == 1:
                    //EUR_PEN
                    //Console.WriteLine("EUR_PEN");
                    importeCalculado = importe * Convert.ToDecimal(moneda[1][4]) * Convert.ToDecimal(moneda[2][6]); ;
                    break;
                case 3 when monedaDestino == 2:
                    //EUR_USD
                    //Console.WriteLine("EUR_USD");
                    importeCalculado = importe * (Convert.ToDecimal(moneda[2][6]));
                    break;
                default:
                    // Código por defecto
                    break;
            }

            Console.Write($"El tipo de cambio es {importeCalculado.ToString()}");
            Console.WriteLine("\n");

            continuarOpcion = false;

            continuarOpcion = OptionContinue(CONVERTIR);
            if (continuarOpcion == true)
            {
                OptionSelection(CONVERTIR, moneda);
            }


        }

        //------------------------------------------------------------------------------------------

        public static void SearchCurrency(Dictionary<int, string[]> moneda)
        {
            string valorBuscar;
            int indice = -1;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--              BUSCAR MONEDA              --");
            Console.WriteLine("---------------------------------------------");

            Console.Write("Digite la moneda para su busqueda: ");
            valorBuscar = Console.ReadLine();

            foreach (var pos in moneda)
            {
                //buscar palabra (por la moneda)
                if (pos.Value.Any(s => s.IndexOf(valorBuscar, StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    indice = pos.Key;
                    break;
                }
            }
            if (indice != -1)
            {
                Console.WriteLine($"Se encontró '{valorBuscar}' en el elemento con clave {indice}");
            }
            else
            {
                Console.WriteLine($"No se encontró '{valorBuscar}' en el diccionario");
                return;
            }
            PrintCurrency(moneda, indice); //imprimir valor buscado

            //Console.WriteLine("Presione enter para retornar a las opciones ...");
            //Console.ReadLine();
            continuarOpcion = false;

            continuarOpcion = OptionContinue(BUSCAR);
            if (continuarOpcion == true)
            {
                OptionSelection(BUSCAR, moneda);
            }

        }

        //------------------------------------------------------------------------------------------
        public static void UpdateCurrency(Dictionary<int, string[]> moneda)
        {
            int opMoneda = -1;
            string newtcp;
            decimal primerTcNuevo = 0, segundoTcNuevo = 0;
            decimal primerTcAnterior, segundoTcAnterior;

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("--      MODIFICAR DATOS DE LA MONEDA       --");
            Console.WriteLine("---------------------------------------------");

            ListCurrencyOptions(moneda);

            bool entradaValida = false;

            while (!entradaValida)
            {
                Console.Write(" Seleccione la opción de la moneda (1-3): ");
                if (int.TryParse(Console.ReadLine(), out opMoneda) == false)
                {
                    Console.WriteLine("Debe ingresar solo valores númericos");
                }
                else
                {
                    if ((moneda.ContainsKey(opMoneda)) == false)
                    {
                        Console.WriteLine($"la Opción de la moneda no es válida"); ;
                    }
                    else
                    {
                        entradaValida = true;
                    }
                }
            }
            //
            Console.WriteLine("");

            primerTcAnterior = Convert.ToDecimal(moneda[opMoneda][4]);
            segundoTcAnterior = Convert.ToDecimal(moneda[opMoneda][6]);

            Console.WriteLine($" Ha seleccionado la moneda en {moneda[opMoneda][0]}, se prodece a modificar el Tipo de cambio ...");

            primerTcNuevo = ValidateExchangeRate(moneda, opMoneda, 3);
            segundoTcNuevo = ValidateExchangeRate(moneda, opMoneda, 5);

            Console.WriteLine("");

            Console.Write("Desea Grabar los cambios? S/N : ");
            string grabar = Console.ReadLine();
            if (grabar.ToUpper() == "S")
            {
                moneda[opMoneda][4] = Convert.ToString(primerTcNuevo);
                moneda[opMoneda][6] = Convert.ToString(segundoTcNuevo);
                Console.WriteLine("Los cambios fueron grabados..");
            }
            else
            {
                moneda[opMoneda][4] = Convert.ToString(primerTcAnterior);
                moneda[opMoneda][6] = Convert.ToString(segundoTcAnterior);
                Console.WriteLine("No se realizó ningún cambio..");
            }

            PrintCurrency(moneda, (opMoneda));

            continuarOpcion = false;

            continuarOpcion = OptionContinue(MODIFICAR);
            if (continuarOpcion == true)
            {
                OptionSelection(MODIFICAR, moneda);
            }

        }

        public static decimal ValidateExchangeRate(Dictionary<int, string[]> moneda, int indice, int indiceArray)
        {
            decimal valorDec = 0;
            bool entradaValida = false;
            //valiacion tipo de cambio es decimal
            while (!entradaValida)
            {
                Console.Write($" - Ingrese el nuevo Tipo de Cambio {moneda[indice][indiceArray]} :");
                if (decimal.TryParse(Console.ReadLine(), out valorDec) == false)
                {
                    Console.WriteLine("Debe ingresar solo valores númericos");
                }
                else
                {
                    entradaValida = true;
                }
            }
            return valorDec;
        }

        public static int NumericalValidationCurrency(Dictionary<int, string[]> moneda, string texto, int opcionOrigen)
        {
            int valorEntero = 0;
            bool entradaValida = false;
            //validacion numerica de las opciones para las monedas

            while (!entradaValida)
            {
                Console.Write($" - Seleccione la moneda {texto} (1-3): ");
                if (int.TryParse(Console.ReadLine(), out valorEntero) == false)
                {
                    Console.WriteLine("Debe ingresar solo valores númericos");
                }
                else
                {
                    if ((moneda.ContainsKey(valorEntero)) == false)
                    {
                        Console.WriteLine($"la Opción de la moneda no es valida");
                    }
                    else if (texto == "Destino" && valorEntero == opcionOrigen)
                    {
                        Console.WriteLine("No se puede realizar la conversión de monedas iguales");
                    }
                    else
                    {
                        entradaValida = true;
                    }
                }
            }
            return valorEntero;
        }



        //------------------------------------------------------------------------------------------
        public static void ListCurrencyOptions(Dictionary<int, string[]> moneda)
        {
            string[] valorMoneda = new string[6];

            Console.WriteLine("\n============ Opciones de Moneda =============");
            foreach (var filas in moneda)
            {
                Console.Write($"      {filas.Key}");
                valorMoneda = filas.Value;
                Console.Write(" - " + valorMoneda[0] + " (" + valorMoneda[1] + ")");
                Console.WriteLine("");
            }
            Console.WriteLine("---------------------------------------------");
        }

        //------------------------------------------------------------------------------------------
        public static Dictionary<int, string[]> InicializarMonedas()
        {
            Dictionary<int, string[]> monedas = new Dictionary<int, string[]>();
            //tcc -tcv
            monedas.Add(1, new string[] { "Soles", "PEN", "S/.", "PEN_USD", "3.75", "PEN_EUR", "3.45" });
            monedas.Add(2, new string[] { "Dolar", "USD", "$", "USD_PEN", "3.74", "USD_EUR", "0.92" });
            monedas.Add(3, new string[] { "Euro", "EUR", "E", "EUR_PEN", "3.44", "EUR_USD", "1.09" });

            return monedas;
        }

        public static void PrintCurrency(Dictionary<int, string[]> moneda, int indice)
        {
            string cabecera;
            string[] valorMoneda = new string[6];

            Console.WriteLine("");
            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            cabecera = " |Moneda      |Abreviatura |Simbolo     |  Tipo de Cambio                                |";
            Console.WriteLine(cabecera);
            Console.WriteLine("+----------------------------------------------------------------------------------------+");

            if (indice == 0)
            {
                foreach (var filas in moneda)
                {
                    valorMoneda = filas.Value;
                    foreach (string filaArray in filas.Value)
                    {
                        Console.Write(" | " + filaArray.PadRight(10));
                    }
                    Console.WriteLine("");
                }
            }
            else
            {
                foreach (string filaArray in moneda[indice])
                {
                    Console.Write(" | " + filaArray.PadRight(10));
                }
                Console.WriteLine("");
            }

            Console.WriteLine("+----------------------------------------------------------------------------------------+");
            Console.WriteLine("\n");
        }

        //------------------------------------------------------------------------------------------
        static bool OptionContinue(int opcion)
        {
            bool opContinue = false;
            string seguir;

            if (opcion != 2)
            {
                seguir = "S";
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
