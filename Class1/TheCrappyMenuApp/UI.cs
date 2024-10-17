namespace UserInput
{
    internal class UI
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


        static bool MenuForLoop(int left, int top)
        {
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.WriteLine("Wie oft soll ich durchschleifen?");
            string? times = Console.ReadLine();

            if ((times != null) && int.TryParse(times, out int realTimes))
            {
                int tmpSum = 0;
                for (int i = 0; i < realTimes; i++)
                {
                    tmpSum += 1;
                }
                top++;
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"Summe: {tmpSum}");
            }

            return true;
        }
        static bool MenuWhile(int left, int top)
        {
            Console.Clear();
            Console.SetCursorPosition(left, top);
            Console.WriteLine("While-Schleife");
            top++;

            int x = 10;
            while (x < 100)
            {
                Console.SetCursorPosition(left, top++);
                Console.WriteLine($"x: {x}");
                x += 10;
            }

            return true;
        }
        static bool MenuDoWhile(int left, int top)
        {
            int x = 0;
            do
            {
                x ++;
                Console.WriteLine($"x: {x}");
            } while (x != 100);
            return true;
        }
        static bool MenuForEach(int left, int top)
        {
            string msg = "hello there you crazy user.";
            foreach (char c in msg)
            {
                Console.WriteLine(c);
            }
            
            return true;
        }

        static void BackToMenu(int left, int top)
        {
            Console.SetCursorPosition(left, top+5);
            Console.WriteLine("Zurück");
            Console.ReadLine();
            PrintMenu(left, top);
        }

        static void Main(string[] args)
        {
            int left = 10;
            int top = 10;

            PrintMenu(left, top);

            char tmpKey = ' ';

            do
            {
                bool exit = false;
                switch (tmpKey)
                {
                    case '1': exit = MenuForLoop(left, top); break;
                    case '2': exit = MenuWhile(left, top); break;
                    case '3': exit = MenuDoWhile(left, top); break;
                    case '4': exit = MenuForEach(left, top); return;
                    default: exit = false; break;
                }

                if (exit)
                {
                    BackToMenu(left, top);
                }

                tmpKey = Console.ReadKey().KeyChar;
            } while (tmpKey != '5');
        }
    }
}