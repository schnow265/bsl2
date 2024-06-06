namespace ControlledStaticMethods
{
    internal class Program
    {
        // The main. You know what Main is, right?!
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
                    Console.WriteLine("Returning to the Menu in 10 seonds...");
                    Thread.Sleep(10000);
                    PrintMenu();
                }

                keypress = Console.ReadKey().KeyChar;
            } while (keypress != '5');
        }


        /*
         * The menu. Not for eating.
         */
        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------");
            Console.WriteLine("|         Drawer            |");
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
            // getting max console buffer size
            int maxWidth = Console.BufferWidth;
            int maxHeight = Console.BufferHeight;

            bool status = false;
            bool length_warning = false;

            // checking if length is -1. We will come back to this later.
            foreach (int length in lengths)
            {
                if (length == -1)
                {
                    return false;
                }
            }


            // Verify that no length is bigger than the buffer size.
            foreach (int length in lengths)
            {
                if (length > maxWidth) { return false; }
                if (length > maxHeight) { return false; }
            }

            // warn the user that lengths are outside of the buffer, and therefore not printable.
            if (!status)
            {
                Console.WriteLine("Some of your lengths are longer than the max buffer size!");
                Console.WriteLine($"The max buffer size is: {maxWidth}x{maxHeight}");
            }
            return true;
        }

        internal static int CheckToInt(string intpls)
        {
            if (int.TryParse(intpls, out int arg1)) { //verify that the given number isn't a string.
                return arg1;
            }
            else
            {
                Console.Error.WriteLine($"VALUE IS NOT A VALID INTEGER");
                return -1; // Oh my god. It's -1.
            }
        }
    }


    internal class Drawing
    {
        // stars.
        static char CHAR_VERT = '*';
        static char CHAR_HORZ = '*';

        // Draws a vertical line Out of stars.
        public static void DrawVLine(int top, int left, int height)
        {
            for (int i = 0; i < height; i++)
            {
                Console.SetCursorPosition(left, top + i);
                Console.Write(CHAR_VERT);
            }
        }

        // Draws a horizontal line. Out of stars.
        public static void DrawHLine(int top, int left, int width)
        {
            Console.SetCursorPosition(left, top);
            for (int i = 0; i < width; i++)
            {
                Console.Write(CHAR_HORZ);
            }
        }

        // Draws a rectangle. Out of lines. Out of stars.
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

        // Draws a grid. Out of Squares. Out of Lines. Out of Stars.
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

    internal class Handlers // handlers which handle various handling jobs.
    {
        internal static bool HandleVerticalLine()
        {
            bool ready = false;
            int top, left, length;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How tall?");
                length = Program.CheckToInt(Console.ReadLine());


                ready = Program.CheckLength(top, left, length);


            } while (!ready);

            Console.Clear(); // clear the space

            Drawing.DrawVLine(top, left, length); // draw it

            return true;
        }

        internal static bool HandleHorizontalLine()
        {
            bool ready = false;
            int top, left, length;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How long?");
                length = Program.CheckToInt(Console.ReadLine());


                ready = Program.CheckLength(top, left, length);


            } while (!ready);

            Console.Clear(); // clear the space

            Drawing.DrawHLine(top, left, length); // draw it

            return true;
        }

        internal static bool HandleSquare()
        {
            bool ready = false;
            int top, left, height, width;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How tall?");
                height = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How much in width?");
                width = Program.CheckToInt(Console.ReadLine());

                ready = Program.CheckLength(top, left, height, width);


            } while (!ready);

            Console.Clear(); // clear the space

            Drawing.DrawRectangle(top,left,height,width); // draw it

            return true;
        }

        internal static bool HandleGrid()
        {
            bool ready = false;
            int top, left, cellSize, numberOfows, numberOfCols;
            do
            {
                Console.WriteLine("How much from the top?");
                top = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How far from the left?");
                left = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How many cells?");
                cellSize = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How many rows?");
                numberOfows = Program.CheckToInt(Console.ReadLine());

                Console.WriteLine("How many cols?");
                numberOfCols = Program.CheckToInt(Console.ReadLine());

                ready = Program.CheckLength(top, left, cellSize, numberOfows, numberOfCols);

            } while (!ready);

            Console.Clear(); // clear the space

            Drawing.DrawGrid(top, left, cellSize, numberOfows, numberOfCols); // draw it

            return true;
        }
    }
}
