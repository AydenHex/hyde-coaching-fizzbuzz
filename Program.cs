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
        Buzz buzz;
        FizzBuzz fizzBuzz;

        public Iteration() {
            this.exporter = new ConsoleExporter();
            this.fizz = new Fizz(this.exporter);
            this.buzz = new Buzz(this.exporter);
            this.fizzBuzz = new FizzBuzz(this.exporter);
        }

        public void Iterate(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
            {
                if (fizzBuzz.verify(i))
                {
                    fizzBuzz.export(i);
                    continue;
                }

                else if (fizz.verify(i)) 
                {
                    fizz.export(i);
                    continue;
                }

                else if (buzz.verify(i))
                {
                    buzz.export(i);
                    continue;
                }
            }
        }
    }

    interface IVerifyAndExport {
        bool verify(int input);
        void export(int input);
    }
    
    public class Fizz : IVerifyAndExport 
    {
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

    public class Buzz : IVerifyAndExport
    {
        IExporter exporter;

        public Buzz(IExporter exporter)
        {
            this.exporter = exporter;
        }

        public bool verify(int input) 
        {
            return input % 5 == 0;
        }

        public void export(int input)
        {
            this.exporter.Export(StringBuilder.Format(input, "Buzz"));
        }
    }

    public class FizzBuzz : IVerifyAndExport
    {
        IExporter exporter;
        Fizz fizz;
        Buzz buzz;

        public FizzBuzz(IExporter exporter)
        {
            this.exporter = exporter;
            this.fizz = new Fizz(this.exporter);
            this.buzz = new Buzz(this.exporter);
        }

        public bool verify(int input)
        {
            return fizz.verify(input) && buzz.verify(input);
        }

        public void export(int input)
        {
            this.exporter.Export(StringBuilder.Format(input, "FizzBuzz"));
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
}
