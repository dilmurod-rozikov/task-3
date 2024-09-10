using System.Text;

public class TableGenerator
{
    private readonly List<string> _moves;
    public TableGenerator(List<string> moves)
    {
        _moves = moves;
    }

    public string GenerateTable()
    {
        int n = _moves.Count;
        StringBuilder table = new();

        table.AppendLine("Results are from the user's point of view:");
        table.AppendLine();

        table.Append("v PC\\User > ");
        foreach (var move in _moves)
            table.Append("| ").Append(move.PadRight(10));
        
        table.AppendLine("|");

        table.Append("+------------");
        for (int i = 0; i < n; i++)
            table.Append('+').Append(new string('-', 11));

        table.AppendLine("+");
        for (int i = 0; i < n; i++)
        {
            table.Append("| ").Append(_moves[i].PadRight(11));
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    table.Append("| ").Append("Draw".PadRight(10));
                else if ((j > i && j <= i + n / 2) || (j < i && j + n <= i + n / 2))
                    table.Append("| ").Append("Win".PadRight(10));
                else
                    table.Append("| ").Append("Lose".PadRight(10));
            }

            table.AppendLine("|");
            table.Append("+-------------");
            for (int k = 0; k < n; k++)
                table.Append('+').Append(new string('-', 11));

            table.AppendLine("+");
        }
        
        return table.ToString();
    }
}