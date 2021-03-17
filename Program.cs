using System;

namespace FizzBuzz
{
    class Program
    {
        // Main = Orchestrateur
        // Si je devais changer l'affichage console en affichage Web, qu'est-ce qui change ?
        // - Console.WriteLine qui disparait
        // - Methode StringBuilder change si on veux changer le format
        static void Main(string[] args)
        {
            // Nombre d'itérations: Sortir le for

            int depart = 1;
            int fin = 100;
            int pas = 1;
            IExporter exporter = new ConsoleExporter();

            for (int i = depart; i <= fin; i+=pas)
            {
                if (Condition.FizzBuzz(i))
                {
                    exporter.Export(StringBuilder.FizzBuzz(i));
                    continue;
                }

                else if (Condition.Fizz(i))
                {
                    exporter.Export(StringBuilder.Fizz(i));
                    continue;
                }

                else if (Condition.Buzz(i))
                {
                    exporter.Export(StringBuilder.Buzz(i));
                    continue;
                }
            }
        }

        
    }

    public interface IExporter
    {
        void Export(string builded);
    }
    public class ConsoleExporter : IExporter {
        public void Export(string builded) {
            Console.WriteLine(builded);
        }
    }

    public class WebExporter : IExporter {
        public void Export(string builded) {}
    }
    // Les deux classes sont très semblable, devrait-on faire qqchose ?
    public class StringBuilder {
        public static string Fizz(int input) {
            return $"{input} Fizz";
        }
        public static string Buzz(int input) {
            return $"{input} Buzz";
        }

        public static string FizzBuzz(int input) {
            return $"{input} FizzBuzz";
        }
    }
    public class Condition {
        public static bool Fizz(int input) { return input % 3 == 0; }
        public static bool Buzz(int input) { return input % 5 == 0; }
        public static bool FizzBuzz(int input) { return Fizz(input) && Buzz(input); }
    }
}
