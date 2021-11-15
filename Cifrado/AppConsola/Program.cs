using System;
using System.IO;
using System.Numerics;
using Cifrado;

namespace AppConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var fi1 = new FileInfo(@"C:\Users\IT\Documents\EG\Cadena.txt");
            var fi2 = new FileInfo(@"C:\Users\IT\Documents\EG\Cadena.rsa");

            Console.WriteLine("------------------------LABORATORIO NO. 6 - CIFRADO RSA-------------------------");
            Cifrado.Clases.RSA cifrado = new Cifrado.Clases.RSA(fi1, fi2);
            cifrado.GenerarLlave(7, 11);

            Console.WriteLine("Ingresar n: ");
            int nC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar d: ");
            int dC = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nTexto a Cifrar: \n");
            cifrado.CrearArchivoCifrado(nC, dC);

            Console.WriteLine("Ingresar n: ");
            int nD = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ingresar e: ");
            int eD = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nTexto a Cifrar: \n");
            cifrado.CrearArchivoDescifrado(nD, eD);

            Console.ReadLine();
        }
    }
}
