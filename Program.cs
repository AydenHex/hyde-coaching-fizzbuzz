using System;

namespace FizzBuzz
{
    class Program
    {
        // Main = Orchestrateur
        static void Main(string[] args)
        {
            // Nombre d'itérations: Sortir le for
            // Affichage:

            int depart = 1;
            int fin = 100;
            int pas = 1;
            for (int i = depart; i <= fin; i+=pas)
            {
                if (Condition.FizzBuzz(i))
                {
                    Console.WriteLine($"{i} : FizzBuzz");
                    continue;
                }

                else if (Condition.Fizz(i))
                {
                    Console.WriteLine($"{i} : Fizz");
                    continue;
                }

                else if (Condition.Buzz(i))
                {
                    Console.WriteLine($"{i} : Buzz");
                    continue;
                }
            }
        }

        
    }

    public class Condition {
        public static bool Fizz(int input) { return input % 3 == 0; }
        public static bool Buzz(int input) { return input % 5 == 0; }
        public static bool FizzBuzz(int input) { return Fizz(input) && Buzz(input); }
    }
}
