namespace MODULE1_CHALLENGE_JONATAN_ARCE
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Menu();

            //Console.WriteLine("Tipo de cambio de Monedas");


            //Dictionary<string, string[]> monedas = new Dictionary<string, string[]>();

            //monedas.Add("PEN", new string[] { "Soles", "3.75", "S/." });
            //monedas.Add("USD", new string[] { "Dolar", "1.09", "$" });
            //monedas.Add("EUR", new string[] { "Euro", "0.92", "€" });

            //var monedas = InicializarMonedas();
            //int[] detalle = new int[2];

            //foreach (var filas in monedas)
            //{
            //    Console.WriteLine($" la Moneda en {filas.Key}: ");

            //    foreach (string filaArray in filas.Value)
            //    {
            //        Console.WriteLine(" - " + filaArray );
            //    }
            //}


        }

        //metodos
        public static void optionSelection(int opcion)
        {
            const int CONVERTIR = 1;
            const int LISTAR = 2;
            const int MODIFICAR = 3;
            const int BUSCAR = 4;
            //const int ADICIONAR = 5;

            Console.WriteLine("");
            switch (opcion)
            {
                case CONVERTIR:
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("--   CONVERTIR MONEDA   --");
                        Console.WriteLine("--------------------------");
                        currencyConvert();
                        break;
                    }
                case LISTAR:
                    {
                        Console.WriteLine("LISTAR");
                        break;
                    }
                case MODIFICAR:
                    {
                        Console.WriteLine("MODIFICAR");
                        break;
                    }
                case BUSCAR:
                    {
                        Console.WriteLine("BUSCAR");
                        break;
                    }
                //case ADICIONAR:
                //    {
                //        Console.WriteLine("ADICIONAR");
                //        break;
                //    }

                default:
                    {
                        Console.WriteLine("FIN");
                        break;
                    }
            }
        }

        public static void Menu()
        {
            int opcion = 0;

            Console.WriteLine("======================================");
            Console.WriteLine("   Aplicación convertidor de moneda   ");
            Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.WriteLine("==== Menú de Opciones ====");
            Console.WriteLine("     1. Convertir moneda");
            Console.WriteLine("     2. Opción 2");
            Console.WriteLine("     3. Opción 3");
            Console.WriteLine("     4. Opción 3");
            //Console.WriteLine("     5. Opción 3");
            Console.WriteLine("     6. Salir");
            Console.WriteLine("--------------------------");
            //Console.WriteLine("");

            while (opcion != 6)
            {
                Console.WriteLine("");
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) == false)
                {
                    Console.WriteLine("Debe ingresar solo valores númericos");
                    return;
                }
                else
                {
                    optionSelection(opcion);
                }

            }
            Console.WriteLine("Fin de programa...");
        }

        public static void currencyConvert()
        {
            var monedas = InicializarMonedas();
            int monedaOrigen, monedaDestino;
            decimal importe, importeCalculado = 0;
            string[] valorMoneda = new string[2];

            Console.WriteLine("\nOpciones Moneda:");

            foreach (var filas in monedas)
            {

                Console.Write($"   {filas.Key}");
                valorMoneda = filas.Value;
                Console.Write(" - " + valorMoneda[0]);

                //foreach (string filaArray in filas.Value)
                //{
                //    Console.Write(" - " + filaArray.);
                //}
                Console.WriteLine("");
            }
            Console.WriteLine("--------------------------");

            Console.Write($" Seleccione la moneda origen: ");
            if (int.TryParse(Console.ReadLine(), out monedaOrigen) == false)
            {
                Console.WriteLine("Debe ingresar solo valores númericos");
                return;
            }
            else
            {
                if ((monedas.ContainsKey(monedaOrigen)) == false)
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
                if ((monedas.ContainsKey(monedaDestino)) == false)
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

        }

        public static Dictionary<int, string[]> InicializarMonedas()
        {
            Dictionary<int, string[]> monedas = new Dictionary<int, string[]>();

            monedas.Add(1, new string[] { "Soles", "PEN", "3.75", "S/." });
            monedas.Add(2, new string[] { "Dolar", "USD", "1.09", "$" });
            monedas.Add(3, new string[] { "Euro", "EUR", "0.92", "€" });

            return monedas;
        }
    }
}
