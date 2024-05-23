namespace UserInput
{
    internal class Program
    {

        static void PrintMenu(int left, int top)
        {
            Console.Clear();
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("1: For-Schleife");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("2: While-Schleift");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("3: Do-While-Schleife");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("4: Foreach Schleife");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("5: Beenden");
        }

        static void Main(string[] args)
        {
            PrintMenu(10, 10);
        }
    }
}