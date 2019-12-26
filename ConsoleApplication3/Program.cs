using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        private const int TotalDisks = 3;
        private const char Inicio = 'A';
        private const char Fin = 'C';
        private const char Temp = 'B';






        public static void Main(string[] args)
        {
            //var stopwatch = new System.Diagnostics.Stopwatch();
            //stopwatch.Start();
            Mueve(TotalDisks, Inicio, Fin, Temp);
            //stopwatch.Stop();
            //Console.Write(stopwatch.Elapsed.ToString());
        }

        private static void Mueve(int n, char inicio, char fin, char temp)
        {
            if (n <= 0) return;

            EscribeTorres(TotalDisks);
            Mueve(n - 1, inicio, temp, fin);// pos inicial

            Console.SetCursorPosition(0, 8);
            Console.WriteLine("Mueva disco " + n + " desde " + inicio + " a " + fin);

            EscribeTorres(TotalDisks);
            Console.ReadLine();
            Console.Clear();

            Mueve(n - 1, temp, fin, inicio); //desde el medio
        }


        protected static void EscribeTorres(int n)
        {

            var alphabet = Enumerable.Range(0, 3).Select(i => Convert.ToChar('A' + i));
            var pos = 0;

            foreach (var letra in alphabet)
            {
                Console.SetCursorPosition(pos, 0);
                for (var i = 1; i <= n; i++)
                {
                   // Console.WriteLine();
                    Console.WriteLine(" ".Repeat(TotalDisks - i) + "*".Repeat(i) + i + "*".Repeat(i));
                }
                Console.SetCursorPosition(pos, n+1);
                Console.WriteLine(" ".Repeat(TotalDisks) + letra);
                pos = 20 + pos;
            }


            Console.WriteLine();
            Console.SetCursorPosition(0, 8);
            //Console.Write(" ---- A ----   --- B ---   --- C --- ");

        }
    }


    public static class StringExtensions
    {
        public static string Repeat(this string instr, int n)
        {
            var result = string.Empty;

            for (var i = 0; i < n; i++)
                result += instr;

            return result;
        }
    }
}
