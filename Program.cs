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
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a moves as a command line argument.");
                return;
            }
            string input = args[0];

            if (input == null || input.Length == 0)
                Console.WriteLine("Please, enter at least 1 move.");
            
            if (args.Length % 2 == 0)
                Console.WriteLine("The number of moves must be odd, in your case it is: " + args.Length);

            Console.WriteLine("Choose your move!");
            for(int i = 1; i <= args.Length; i++)
                Console.WriteLine(i + " - " + args[i-1]);
            
        }
    }
}