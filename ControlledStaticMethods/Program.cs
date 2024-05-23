namespace ControlledStaticMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintMenu();

            char keypress = ' ';

            do
            {
                bool exit = false;

                switch (keypress)
                {
                    case '1': exit = Handlers.HandleVerticalLine(); break;
                    case '2': exit = Handlers.HandleHorizontalLine(); break;
                    case '3': exit = Handlers.HandleSquare(); break;
                    case '4': exit = Handlers.HandleGrid(); break;
                    default: exit = false; break;
                }

                if (exit)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Returning to the Menu in 2 seonds...");
                    Thread.Sleep(2000);
                    PrintMenu();
                }

                keypress = Console.ReadKey().KeyChar;
            } while (keypress != '5');
        }


        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| °       Drawer          ° |");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| 1: Draw vertical Line     |");
            Console.WriteLine("| 2: Draw horizontal Line   |");
            Console.WriteLine("| 3: Draw square            |");
            Console.WriteLine("| 4: Draw Grid              |");
            Console.WriteLine("| 5: Exit                   |");
            Console.WriteLine("-----------------------------");
        }

        internal static bool CheckLength(params int[] lengths)
        {
            int maxWidth = Console.BufferWidth;
            int maxHeight = Console.BufferHeight;

            bool status = false;
            bool length_warning = false;

            foreach (int length in lengths)
            {
                if (length > maxWidth) { status = false; break; }
                if (length > maxHeight) { status = false; break; }
            }

            if (!status)
            {
                Console.WriteLine("Some of your lengths are longer than the max buffer size!");
                Console.WriteLine($"The max buffer size is: {maxWidth}x{maxHeight}");
            }
            return true;
        }
    }


    internal class Drawing
    {
        static char CHAR_TO_DRAW = '*';

        // Draws a vertical line
        public static void DrawVLine(int top, int left, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(CHAR_TO_DRAW);
            }
        }

        // Draws a horizontal line
        public static void DrawHLine(int top, int left, int width)
        {
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < width; i++)
            {
                Console.Write(CHAR_TO_DRAW);
            }
        }

        // Draws a rectangle
        public static void DrawRectangle(int top, int left, int height, int width)
        {
            // Top horizontal line
            DrawHLine(top, left, width);

            // Bottom horizontal line
            DrawHLine(top + height - 1, left, width);

            // Left vertical line
            DrawVLine(top, left, height);

            // Right vertical line
            DrawVLine(top, left + width - 1, height);
        }

        // Draws a grid
        public static void DrawGrid(int top, int left, int cellSize, int numberOfRows, int numberOfColumns)
        {
            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < numberOfColumns; col++)
                {
                    int rectTop = top + row * cellSize;
                    int rectLeft = left + col * cellSize;
                    DrawRectangle(rectTop, rectLeft, cellSize, cellSize);
                }
            }
        }
    }

    internal class Handlers
    {
        internal static bool HandleVerticalLine()
        {
            bool ready = false;
            int top, left, length;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How tall?");
                length = Convert.ToInt32(Console.ReadLine());


                ready = Program.CheckLength(top, left, length);


            } while (!ready);

            Console.Clear();

            Drawing.DrawVLine(top, left, length);

            return true;
        }

        internal static bool HandleHorizontalLine()
        {
            bool ready = false;
            int top, left, length;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How long?");
                length = Convert.ToInt32(Console.ReadLine());


                ready = Program.CheckLength(top, left, length);


            } while (!ready);

            Console.Clear();

            Drawing.DrawHLine(top, left, length);

            return true;
        }

        internal static bool HandleSquare()
        {
            bool ready = false;
            int top, left, height, width;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How tall?");
                height = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How much in width?");
                width = Convert.ToInt32(Console.ReadLine());

                ready = Program.CheckLength(top, left, height, width);


            } while (!ready);

            Console.Clear();

            Drawing.DrawRectangle(top,left,height,width);

            return true;
        }

        internal static bool HandleGrid()
        {
            bool ready = false;
            int top, left, cellSize, numberOfows, numberOfCols;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many cells?");
                cellSize = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many rows?");
                numberOfows = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("How many cols?");
                numberOfCols = Convert.ToInt32(Console.ReadLine());

                ready = Program.CheckLength(top, left, cellSize, numberOfows, numberOfCols);


            } while (!ready);

            Console.Clear();

            Drawing.DrawGrid(top, left, cellSize, numberOfows, numberOfCols);

            return true;
        }
    }
}
