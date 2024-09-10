using Task3.classes;

namespace Task3
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a moves as a command line argument.");
                return;
            }
            string? input = args[0];

            if (input == null || input.Length == 0)
                Console.WriteLine("Please, enter at least 1 move.");

            if (args.Length % 2 == 0)
                Console.WriteLine("The number of moves must be odd, in your case it is: " + args.Length);

            Random random= new();
            int computer = random.Next(args.Length);

            //generate HMAC
            List<string> moves = args.ToList();
            byte[] key = KeyGenerator.GenerateKey();
            string hmac = HMACGenerator.GenerateHMAC(moves[computer-1], key);

            Console.WriteLine("Choose your move by its id!");
            for (int i = 1; i <= args.Length; i++)
                Console.WriteLine(i + " - " + args[i - 1]);

            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            char player;
            while (true)
            {
                player = Convert.ToChar(Console.Read());
                if (player == '0')
                    break;

                if(player == '?')
                {
                    TableGenerator tg = new TableGenerator(moves);
                    Console.WriteLine(tg.GenerateTable());
                }

                if (computer > player)
                    Console.WriteLine("Computer wins!");
                else if (computer == player)
                    Console.WriteLine("Draw!");
                else if (player > computer)
                    Console.WriteLine("You win!!!");
                else
                    Console.WriteLine("Wrong move");

                Console.WriteLine("Your move: " + args[player - 1]);
                Console.WriteLine("Computer's move: " + args[computer]);
                Console.WriteLine("HMAC key: " + BitConverter.ToString(key).Replace("-", "").ToLower());
                break;
            }
        }
    }
}