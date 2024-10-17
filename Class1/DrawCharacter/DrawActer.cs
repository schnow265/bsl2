namespace DrawCharacter
{
    internal class DrawActer
    {
        static void Main(string[] args)
        {
            // Check if there are less then three arguments.
            if (args.Length < 3)
            {
                Console.WriteLine("You need to supply three arguments");
            }
            else
            {
                // verify thet argument 1 is an integer
                if (int.TryParse(args[0], out int arg1))
                {
                    // verify  thet argument 2 is an integer
                    if (int.TryParse(args[1], out int arg2))
                    {
                        // set the character to print from argument 3
                        string character = args[2];

                        // verify that user only entrered one char.
                        if (character.Length > 1)
                        {
                            Console.WriteLine("Your character isn't supposed to be longer than one!");
                        }
                        else
                        {
                            PrintCenteredCharacter(arg1, arg2, character);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Give an integer at position 2!");
                    }

                }
                else
                {
                    Console.WriteLine("Give an integer at position 1!");
                }
            }
        }

        static void PrintCenteredCharacter(int rows, int columns, string character)
        {
            // Save window size, to restore later
            int origWidth = Console.WindowWidth;
            int origHeight = Console.WindowHeight;

            // clear console & set size
            Console.Clear();
            Console.SetWindowSize(rows * 2, columns * 2);

            // Calculate the number of spaces needed for centering
            int leftPadding = (Console.WindowWidth - columns) / 2;
            int topPadding = (Console.WindowHeight - rows) / 2;

            // Ensure that the character fits within the console window
            if (leftPadding < 0 || topPadding < 0)
            {
                Console.WriteLine("Character does not fit within the console window.");
                return;
            }

            // Print top padding
            for (int i = 0; i < topPadding; i++)
            {
                Console.WriteLine();
            }

            // Print the character pattern
            for (int i = 0; i < rows; i++)
            {
                // Left padding
                for (int j = 0; j < leftPadding; j++)
                {
                    Console.Write(' ');
                }

                // Characters
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(character);
                }

                Console.WriteLine();
            }

            // pause for 5 seconss
            Thread.Sleep(5000);

            // restore old window size
            Console.SetWindowSize(origWidth, origHeight);
        }
    }
}