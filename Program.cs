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

            int start = 1;
            int end = 100;
            int step = 1;
            Iteration iteration = new Iteration();

            iteration.Iterate(start, end, step);
        }
    }

    public interface IExporter
    {
        void Export(string builded);
    }

    public class ConsoleExporter : IExporter
    {
        public void Export(string builded)
        {
            Console.WriteLine(builded);
        }
    }

    public class Iteration
    {
        IExporter exporter;
        Fizz fizz;

        public Iteration() {
            this.exporter = new ConsoleExporter();
            this.fizz = new Fizz(this.exporter);
        }

        public void Iterate(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
            {
                if (Condition.FizzBuzz(i))
                {
                    exporter.Export(StringBuilder.Format(i, "FizzBuzz"));
                    continue;
                }

                else if (fizz.verify(i)) 
                {
                    fizz.export(i);
                    continue;
                }

                else if (Condition.Buzz(i))
                {
                    exporter.Export(StringBuilder.Format(i, "Buzz"));
                    continue;
                }
            }
        }
    }

    public class Fizz {
        IExporter exporter;

        public Fizz(IExporter exporter) 
        {
            this.exporter = exporter;
        }

        public bool verify(int input) {
            return input % 3 == 0;
        }
        
        public void export(int input) {
            this.exporter.Export(StringBuilder.Format(input, "Fizz"));
            
        }
    }

    public class WebExporter : IExporter
    {
        public void Export(string builded) { }
    }

    // Les deux classes sont très semblable, devrait-on faire qqchose ?
    public class StringBuilder
    {
        public static string Format(int input, string result)
        {
            return $"{input} - {result}";
        }
    }
    public class Condition
    {
        public static bool Fizz(int input) { return input % 3 == 0; }
        public static bool Buzz(int input) { return input % 5 == 0; }
        public static bool FizzBuzz(int input) { return Fizz(input) && Buzz(input); }
    }
}
