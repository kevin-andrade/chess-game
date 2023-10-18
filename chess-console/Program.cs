namespace chess_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p;

            p = new Position(3, 4);

            Console.WriteLine("Position: " + p);
        }
    }
}