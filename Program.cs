public class using Greet;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Please, enter odd number of moves!");
            Console.WriteLine("Please, use empty space or comma to separte the words!");

            while (true)
            {
                string? moves = Console.ReadLine();
                if (moves == null || moves.Length == 0)
                {
                    Console.WriteLine("Please, enter at least 1 move.");
                    continue;
                }    

                string[] movesArr = moves!.Split([',', ' '], StringSplitOptions.RemoveEmptyEntries);
                if (movesArr.Length % 2 == 0)
                {
                    Console.WriteLine("The number of moves must be odd, in your case it is: " + movesArr.Length);
                    continue;
                }
                
            }
        }
    }
}