using Task3.classes;

namespace Task3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a move as a command line argument.");
                return;
            }
            List<string> moves = new(args);

            if (moves.Count == 0)
            {
                Console.WriteLine("Please, enter at least 1 move.");
                return;
            }

            if (moves.Count % 2 == 0)
            {
                Console.WriteLine("The number of moves must be odd, in your case it is: " + moves.Count);
                return;
            }

            Random random = new();
            int computer = random.Next(moves.Count);

            // Generate HMAC
            byte[] key = KeyGenerator.GenerateKey();
            string hmac = HMACGenerator.GenerateHMAC(moves[computer], key);

            Console.WriteLine("HMAC: " + hmac);
            Console.WriteLine("Choose your move by its id!");
            for (int i = 0; i < moves.Count; i++)
                Console.WriteLine(i + 1 + " - " + moves[i]);

            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");

            while (true)
            {
                string? input = Console.ReadLine();

                if (input == "0")
                    break;

                if (input == "?")
                {
                    TableGenerator tg = new(moves);
                    Console.WriteLine(tg.GenerateTable());
                    Console.WriteLine("Choose your move: ");
                    continue;
                }

                if (int.TryParse(input, out int player) && player >= 1 && player <= moves.Count)
                {
                    player--; 

                    if (computer > player)
                        Console.WriteLine("Computer wins!");
                    else if (computer == player)
                        Console.WriteLine("Draw!");
                    else
                        Console.WriteLine("You win!!!");

                    Console.WriteLine("Your move: " + moves[player]);
                    Console.WriteLine("Computer's move: " + moves[computer]);
                    Console.WriteLine("HMAC key: " + BitConverter.ToString(key).Replace("-", "").ToLower());
                    break;
                }
                else
                    Console.WriteLine("Wrong move, try again.");
            }
        }
    }
}
