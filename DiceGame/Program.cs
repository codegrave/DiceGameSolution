using System;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var scorer = new Scorer();
            var role = new Role(2, 8, 2, 8, 1);
            var results = scorer.AllScores(role);
            foreach (var result in results)
            {
                Console.WriteLine("{0}: {1}", result.Category, result.Score);
            }
            Console.ReadKey();
        }
    }
}
