using System.ComponentModel.Design;

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
            Console.WriteLine("======================================");
            Console.WriteLine("   Aplicación convertidor de moneda   ");
            Console.WriteLine("======================================");
            Console.WriteLine("");
            Console.WriteLine("==== Menú de Opciones ====");
            Console.WriteLine("     1. Convertir moneda");
            Console.WriteLine("     2. Listar");
            Console.WriteLine("     3. Editar");
            Console.WriteLine("     4. Buscar");
            Console.WriteLine("     5. Salir");
            Console.WriteLine("--------------------------");
            Console.WriteLine("\n");
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
                Console.Write("Ingrese su opción: ");
                if (int.TryParse(Console.ReadLine(), out opcion) == false)
                {
                    Console.WriteLine("Opciones - Debe ingresar solo valores númericos");
                    return;
                }
                else
                {   if (opcion != 5)
                    { 
                        optionSelection(opcion);  //Evaluar opciones
                        opContinue = opcionSeguir();
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
            
            switch (opcion)
            {
                case CONVERTIR:
                    {                 
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
                default:
                    {
                        Console.WriteLine("Ingrese correctamente la Opcion");
                        break;
                    }
            }

        }

 

  

        //------------------------------------------------------------------------------------------
        public static void currencyConvert()
        {
            var monedas = InicializarMonedas();
            int monedaOrigen, monedaDestino;
            decimal importe, importeCalculado = 0;
            string[] valorMoneda = new string[2];

            Console.WriteLine("--------------------------");
            Console.WriteLine("--   CONVERTIR MONEDA   --");
            Console.WriteLine("--------------------------");

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
            Console.WriteLine("");

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
        static bool opcionSeguir()
        {
            bool opContinue=false;
            string seguir="S";

            //while (seguir == "S" || seguir == "s")

            Console.Write("Desea ingresar otro? S/N : ");
            seguir = Console.ReadLine();
            if (seguir == "S" || seguir == "s")
            {
                opContinue = true;
            }
            else 
            {
                opContinue = false;
            }              
            return opContinue;
        }


    }
}
