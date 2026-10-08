using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaurensUrbina
{

    class Program
    {
        static void Main(string[] args)
        {
            const int N = 14;
            string[] ced = new string[N];
            string[] nom = new string[N];
            int[] eda = new int[N];
            string[] san = new string[N];
            string[] mot = new string[N];
            int cant = 0;
            int op = 0;

            for (int i = 0; i < N; i++)
            {
                ced[i] = "";
                nom[i] = "";
                eda[i] = 0;
                san[i] = "";
                mot[i] = "";
            }

            while (op != 6)
            {
                Console.WriteLine("\n1. Registrar");
                Console.WriteLine("2. Buscar por cedula");
                Console.WriteLine("3. Corregir datos");
                Console.WriteLine("4. Dar de baja");
                Console.WriteLine("5. Reporte");
                Console.WriteLine("6. Salir");
                Console.Write("Opcion: ");
                op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    if (cant == N)
                    {
                        Console.WriteLine("Memoria llena");
                    }
                    else
                    {
                        Console.Write("Cedula: ");
                        string c = Console.ReadLine();
                        if (Buscar(ced, cant, c) != -1)
                        {
                            Console.WriteLine("Cedula repetida");
                        }
                        else
                        {
                            ced[cant] = c;
                            Console.Write("Nombre: ");
                            nom[cant] = Console.ReadLine();
                            Console.Write("Edad: ");
                            eda[cant] = int.Parse(Console.ReadLine());
                            Console.Write("Tipo de sangre: ");
                            san[cant] = Console.ReadLine();
                            Console.Write("Motivo de consulta: ");
                            mot[cant] = Console.ReadLine();
                            cant++;
                        }
                    }
                }
                else if (op == 2)
                {
                    Console.Write("Cedula: ");
                    int pos = Buscar(ced, cant, Console.ReadLine());
                    if (pos == -1)
                    {
                        Console.WriteLine("No existe");
                    }
                    else
                    {
                        Console.WriteLine("Nombre: " + nom[pos]);
                        Console.WriteLine("Edad: " + eda[pos]);
                        Console.WriteLine("Tipo de sangre: " + san[pos]);
                        Console.WriteLine("Motivo: " + mot[pos]);
                    }
                }
                else if (op == 3)
                {
                    Console.Write("Cedula: ");
                    int pos = Buscar(ced, cant, Console.ReadLine());
                    if (pos == -1)
                    {
                        Console.WriteLine("No existe");
                    }
                    else
                    {
                        Console.Write("Nuevo nombre: ");
                        nom[pos] = Console.ReadLine();
                        Console.Write("Nueva edad: ");
                        eda[pos] = int.Parse(Console.ReadLine());
                        Console.Write("Nuevo tipo de sangre: ");
                        san[pos] = Console.ReadLine();
                        Console.Write("Nuevo motivo: ");
                        mot[pos] = Console.ReadLine();
                    }
                }
                else if (op == 4)
                {
                    Console.Write("Cedula: ");
                    int pos = Buscar(ced, cant, Console.ReadLine());
                    if (pos == -1)
                    {
                        Console.WriteLine("No existe");
                    }
                    else
                    {
                        for (int i = pos; i < cant - 1; i++)
                        {
                            ced[i] = ced[i + 1];
                            nom[i] = nom[i + 1];
                            eda[i] = eda[i + 1];
                            san[i] = san[i + 1];
                            mot[i] = mot[i + 1];
                        }
                        cant--;
                        ced[cant] = "";
                        nom[cant] = "";
                        eda[cant] = 0;
                        san[cant] = "";
                        mot[cant] = "";
                    }
                }
                else if (op == 5)
                {
                    Console.WriteLine("\n--- REPORTE DE ADMISIONES ---");
                    if (cant == 0)
                    {
                        Console.WriteLine("No hay personas registradas");
                    }
                    else
                    {
                        for (int i = 0; i < cant; i++)
                            Console.WriteLine((i + 1) + ". " + ced[i] + " - " + nom[i] + " - " + eda[i] + " años - " + san[i] + " - " + mot[i]);
                    }
                    Console.WriteLine("Registrados: " + cant + " de " + N);
                    Console.WriteLine("Espacios libres: " + (N - cant));
                }
            }
        }

        static int Buscar(string[] ced, int cant, string c)
        {
            for (int i = 0; i < cant; i++)
            {
                if (ced[i] == c)
                    return i;
            }
            return -1;
        }
    }
}
