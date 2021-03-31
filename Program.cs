using System;
using System.Collections.Generic;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            int start = 1;
            int end = 100;
            int step = 1;
            IExporter exporter = new ConsoleExporter();
            List<IVerifyAndExport> test = new List<IVerifyAndExport>{
                new FizzBuzz(exporter),
                new Fizz(exporter),
                new Buzz(exporter),
            };
            Iteration iteration = new Iteration(test);

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
        List<IVerifyAndExport> verifyAndExport;

        public Iteration(List<IVerifyAndExport> verifyAndExport) {
            this.verifyAndExport = verifyAndExport;
        }

        public void Iterate(int start, int end, int step)
        {
            for (int i = start; i <= end; i += step)
            {
                foreach(var myVerifyAndExport in this.verifyAndExport) {
                    if (myVerifyAndExport.verify(i))
                    {
                        myVerifyAndExport.export(i);
                        break;
                    }
                }
            }
        }
    }

    public interface IVerifyAndExport {
        bool verify(int input);
        void export(int input);
    }
    
    public class Fizz : IVerifyAndExport 
    {
        IExporter exporter;
        const name = "Fizz";

        public Fizz(IExporter exporter) 
        {
            this.exporter = exporter;
        }

        public bool verify(int input) {
            return input % 3 == 0;
        }
        
        public void export(int input) {
            this.exporter.Export(StringBuilder.Format(input, name));      
        }
    }

    public class Buzz : IVerifyAndExport
    {
        IExporter exporter;
        const name = "Buzz";

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
            this.exporter.Export(StringBuilder.Format(input, name));
        }
    }

    public class FizzBuzz : IVerifyAndExport
    {
        IExporter exporter;
        Fizz fizz;
        Buzz buzz;
        const name = "FizzBuzz";

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
            this.exporter.Export(StringBuilder.Format(input, name));
        }
    }

    public class WebExporter : IExporter
    {
        public void Export(string builded) { }
    }

    // Possiblement problématique pour les tests.. a réflechir !
    public class StringBuilder
    {
        public static string Format(int input, string result)
        {
            return $"{input} - {result}";
        }
    }
}
