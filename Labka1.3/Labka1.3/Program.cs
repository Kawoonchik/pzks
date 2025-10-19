
using System.Text;

abstract class Figure
{
    public int X { get; set; }
    public int Y { get; set; }
    public string Color { get; set; } 

    public bool isAttacked { get; set; } = false;


    public Figure(int x, int y, string color, bool isAttacked)
    {
        X = x;
        Y = y;
        Color = color;
        isAttacked = false;
    }

    

    public abstract List<(int, int)> GetMoves();

    

    public bool CanAttack(Figure other)
    {
        var moves = GetMoves();
        return moves.Any(m => m.Item1 == other.X && m.Item2 == other.Y && this.Color != other.Color);
    }


    public bool CanDefend(Figure other)
    {
        var moves = GetMoves();
        return this.Color == other.Color   
            && other.isAttacked            
            && moves.Any(m => m.Item1 == other.X && m.Item2 == other.Y);
    }
}








class Queen : Figure
{
    public Queen(int x, int y, string color, bool isAttacked) : base(x, y, color, isAttacked) { }

 

    public override List<(int, int)> GetMoves()
    {
        var moves = new List<(int, int)>();

  
        int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
        int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };

        for (int dir = 0; dir < 8; dir++)
        {
            for (int step = 1; step <= 8; step++) 
            {
                int newX = X + dx[dir] * step;
                int newY = Y + dy[dir] * step;
                if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                    moves.Add((newX, newY));
                else break; 
            }
        }
        return moves;
    }
}

class Rook : Figure
{
    public Rook(int x, int y, string color, bool isAttacked) : base(x, y, color, isAttacked) { }

    public override List<(int, int)> GetMoves()
    {
        var moves = new List<(int, int)>();
        int[] dx = { -1, 1, 0, 0 };
        int[] dy = { 0, 0, -1, 1 };

        for (int dir = 0; dir < 4; dir++)
        {
            for (int step = 1; step <= 8; step++)
            {
                int newX = X + dx[dir] * step;
                int newY = Y + dy[dir] * step;
                if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                    moves.Add((newX, newY));
                else break;
            }
        }
        return moves;
    }
}

class King : Figure
{
    public King(int x, int y, string color, bool isAttacked) : base(x, y, color, isAttacked) { }

    public override List<(int, int)> GetMoves()
    {
        var moves = new List<(int, int)>();
        int[] dx = { -1, 1, 0, 0, -1, -1, 1, 1 };
        int[] dy = { 0, 0, -1, 1, -1, 1, -1, 1 };

        for (int dir = 0; dir < 8; dir++)
        {
            int newX = X + dx[dir];
            int newY = Y + dy[dir];
            if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                moves.Add((newX, newY));
        }
        return moves;
    }
}








class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        Console.WriteLine("Введіть координати (від 1 до 8)");

        Console.Write("Ферзь (x y): ");
        var q = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Queen queen = new Queen(q[0], q[1], "white", false);

        Console.Write("Король (x y): ");
        var k = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        King king = new King(k[0], k[1], "black", false);

        Console.Write("Тура (x y): ");
        var r = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        Rook rook = new Rook(r[0], r[1], "black", false);

        List<Figure> figures = new List<Figure> { queen, king, rook };


        foreach (var fig in figures)
        {
            foreach (var other in figures)
            {
                if (fig == other) continue;
                if (fig.CanAttack(other))
                    other.isAttacked = true;
            }
        }


        foreach (var fig in figures)
        {
            Console.WriteLine($"\nФігура: {fig.GetType().Name} ({fig.Color}), координати ({fig.X},{fig.Y})");

            bool actionDone = false;
            foreach (var other in figures)
            {
                if (fig == other) continue;

                if (fig.CanAttack(other))
                {
                    Console.WriteLine($"  Може атакувати {other.GetType().Name} на ({other.X},{other.Y})");
                    actionDone = true;
                }
                else if (fig.CanDefend(other))
                {
                    Console.WriteLine($"  Захищає {other.GetType().Name} на ({other.X},{other.Y})");
                    actionDone = true;
                }
            }

            if (!actionDone)
                Console.WriteLine("  Простий хід (ніхто не під атакою і не під захистом).");
        }
    }
}
