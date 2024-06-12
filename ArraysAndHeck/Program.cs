namespace ArraysAndHeck
{
    internal class Program
    {
        static void PrintMenu(int left, int top) // well, print the menu
        {
            Console.Clear();
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("1: Eindimensionales Array");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("2: Multipliziere Arrays");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("3: Primzahlen");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("4: Zufallszahlen");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("5: Zweidimensionales Quadratisches Array");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("6: Chessboard");
            Console.SetCursorPosition(left, top++);
            Console.WriteLine("7: Quit");
        }

        static void Main(string[] args) // this is Main. Say hi to Main.
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
                    case '1': exit = MenuHandlers.HandleMenu01(left, top); break;
                    case '2': exit = MenuHandlers.HandleMenu02(left, top); break;
                    case '3': exit = MenuHandlers.HandleMenu03(left, top); break;
                    case '4': exit = MenuHandlers.HandleMenu04(left, top); break;
                    case '5': exit = MenuHandlers.HandleMenu05(left, top); break;
                    case '6': exit = MenuHandlers.HandleMenu06(left, top); break;
                    default: exit = false; break;
                }

                if (exit)
                {
                    BackToMenu(left, top);
                }

                tmpKey = Console.ReadKey().KeyChar; // I like this here. I will not move this.
            } while (tmpKey != '7');
        }

        static void BackToMenu(int left, int top)
        {
            Console.SetCursorPosition(left, top + 5);
            Console.WriteLine("Zurück");
            Console.ReadLine(); // no timer - easier for screenshots.
            PrintMenu(left, top);
        }
    }

    public class MenuHandlers
    {
        public static bool HandleMenu01(int left, int top) // make array with one value
        {
            Console.Clear();

            bool ready = false;
            int size = 0;
            int val = 0;

            do
            {
                Console.WriteLine("Wie groß solls sein?");
                size = Utils.CheckToInt(Console.ReadLine());

                Console.WriteLine("Welcher Wert soll drinnen sein?");
                val = Utils.CheckToInt(Console.ReadLine());

                ready = Utils.CheckInts(val, size);
            } while (!ready);

            ArrayStuff.PrintArray(ArrayStuff.InitArr(size, val));

            return true;
        }
        public static bool HandleMenu02(int left, int top) // mul arr1, arr2
        {
            Console.Clear();

            // split checks so that the user doesn't need to redo the entire form if they don't do one correctly.

            // init the vars for size & the bools for check
            int[] one = null; int[] two = null;
            int size1 = 0; int size2 = 0;
            bool ready = false; bool size1Check = false; bool size2Check = false;

            // Array #1 init
            do
            {
                Console.WriteLine("Wie Groß soll Array 1 sein?");
                size1 = Utils.CheckToInt(Console.ReadLine());
                size1Check = Utils.CheckInts(size1);
            } while (!size1Check);
            one = new int[size1];

            // Array 2 init
            do
            {
                Console.WriteLine("Wir groß soll Array 2 sein?");
                size2 = Utils.CheckToInt(Console.ReadLine());
                size2Check = Utils.CheckInts(size2);
            } while (!size2Check);
            two = new int[size2];

            // array 1 filling
            int i = 0;
            while (i < size1)
            {
                Console.WriteLine($"Zahl an Position {i + 1} im 1. Array: ");
                int num = Utils.CheckToInt(Console.ReadLine());
                if (Utils.CheckInts(num))
                {
                    one[i] = num;
                    i++;
                }
            }

            // array 2 filling
            int j = 0;
            while (j < size2)
            {
                Console.WriteLine($"Zahl an Position {j + 1} im 2. Array: ");
                int num = Utils.CheckToInt(Console.ReadLine());
                if (Utils.CheckInts(num))
                {
                    two[j] = num;
                    j++;
                }
            }

            // Array Printing     // Array Multiplication
            ArrayStuff.PrintArray(ArrayStuff.MultiplyArray(one, two));

            return true;
        }
        public static bool HandleMenu03(int left, int top) // Prime Number Array
        {
            Console.Clear();
            bool ready = false; int primCount = 0;
            do
            {
                Console.WriteLine("Bis zu welcher Zahl sollen die Primzahlen ingelesen werden?");
                primCount = Utils.CheckToInt(Console.ReadLine());
                ready = Utils.CheckInts(primCount);
            } while (!ready);

            // Get primes & print them.
            ArrayStuff.PrintArray(ArrayStuff.getPrimes(primCount));

            return true;
        }
        public static bool HandleMenu04(int left, int top) // Random Number Array
        {
            Console.Clear();

            bool ready = false; int max = 0; int count = 0;

            do
            {
                Console.WriteLine("Wie hoch maximal?");
                max = Utils.CheckToInt(Console.ReadLine());

                Console.WriteLine("Wie viele Zahlen sollen es sein?");
                count = Utils.CheckToInt(Console.ReadLine());

                ready = Utils.CheckInts(max, count);
            } while (!ready);

            ArrayStuff.PrintArray(ArrayStuff.GetRandomNumbers(max, count));
            return true;
        }
        public static bool HandleMenu05(int left, int top) // Square 2D Array
        {
            Console.Clear();

            bool ready = false;
            int length = 0;
            int val = 0;

            do
            {
                Console.WriteLine("Wie lang/breit? (Selber wert)");
                length = Utils.CheckToInt(Console.ReadLine());

                Console.WriteLine("Welcher Wert?");
                val = Utils.CheckToInt(Console.ReadLine());

                ready = Utils.CheckInts(length, val);
            } while (!ready);

            ArrayStuff.PrintTab(ArrayStuff.InitTable(length, val));

            return true;
        }
        public static bool HandleMenu06(int left, int top) // Chess board pattern
        {
            Console.Clear();

            int size = 0;
            bool ready = false;
            do
            {
                Console.WriteLine("How big should the board be?");
                size = Utils.CheckToInt(Console.ReadLine());

                ready = Utils.CheckInts(size);
            } while (!ready);

            char[,] board = ArrayStuff.ChessBoardMaker(size);


            ArrayStuff.ChessboardPrinter(board);


            return true;
        }
    }

    internal class ArrayStuff
    {
        public static void PrintArray(int[] arr) // 1D array printer
        {
            Console.Clear();
            Console.Write("[ ");
            foreach (int element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("]");
        }

        public static void PrintTab(int[,] array) // 2D array printer
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                Console.Write("[ ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        public static void ChessboardPrinter(char[,] array) // Chessboard Printer
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static int[] InitArr(int size, int val) // init an array with fixed size & only one value.
        {
            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = val;
            }

            return arr;
        }

        public static int[,] InitTable(int size, int val) // init an 2d array with ^fixed one value.
        {
            int[,] arr = new int[size, size];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = val;
                }
            }

            return arr;
        }

        public static char[,] ChessBoardMaker(int size) // create chessboard
        {
            char[,] board = new char[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        board[i, j] = ' ';
                    }
                    else
                    {
                        board[i, j] = '*';
                    }
                }
            }

            return board;
        }

        public static int[] MultiplyArray(int[] arr1, int[] arr2) // Array Multiplication.
        {
            int[] res = null;
            int maxSize = 0;

            if (arr1.Length == arr2.Length) // perfectly fine.
            {
                res = new int[arr1.Length];
            }
            else // oh god.
            {
                maxSize = Math.Max(arr1.Length, arr2.Length);
                res = new int[maxSize];
                bool arr1IsLonger = false;

                int[] tmp = null; // temp array for storage

                if (arr1.Length > arr2.Length) // arr1 longer than arr2
                {
                    arr1IsLonger = true;
                    tmp = arr1;
                }
                else                           // arr2 longer than arr1
                {
                    arr1IsLonger = false;
                    tmp = arr2;
                }

                if (arr1IsLonger) // code if 1 is the longer array
                {
                    for (int i = 0; i < maxSize; i++)
                    {
                        if (tmp.Length >= i)
                        {
                            arr1[i] = 1;
                        }
                        else
                        {
                            arr1[i] = tmp[i];
                        }
                    }
                }
                else // code if 2 is longer
                {
                    for (int i = 0; i < maxSize; i++)
                    {
                        if (tmp.Length >= i)
                        {
                            arr2[i] = 1;
                        }
                        else
                        {
                            arr2[i] = tmp[i];
                        }
                    }
                }
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                res[i] = arr1[i] * arr2[i]; // this is the multiplication. three rows.
            }

            return res;
        }

        public static int[] getPrimes(int max) // get prime numbers
        {
            List<int> ints = new List<int>(); // wait, this isn't an array...

            bool isPrime = false;

            for (int i = 0; i < max; i++)
            {
                isPrime = Utils.VerifyPrime(i);

                if (isPrime)
                {
                    ints.Add(i);
                }
            }

            return ints.ToArray(); // well it's one now.
        }

        public static int[] GetRandomNumbers(int max, int count) // we get random numbers, what do you expect?
        {
            int[] rand = new int[count];
            Random r = new Random();

            for (int i = 0; i < count; i++)
            {
                rand[i] = r.Next(0, max);
            }

            return rand;
        }
    }

    internal class Utils
    { 
        internal static int CheckToInt(string intpls) // well, look who's back.
        {
            if (int.TryParse(intpls, out int arg1))
            { //verify that the given number isn't a string, again.
                return arg1;
            }
            else
            {
                return -1; // Oh my god. It's -1, again.
            }
        }

        internal static bool CheckInts(params int[] ints) // also back in use.
        {
            foreach (int length in ints)
            {
                if (length == -1)
                {
                    Console.Error.WriteLine($"VALUE IS NOT A VALID INTEGER");
                    return false;
                }
            }
            return true;
        }

        internal static bool VerifyPrime(int prime) // this one knows if the number is a prime number.
        {
            bool isPrime = true;
            int i = 2; // start at two, to that it doesn't stop at 1.

            while (i < prime && isPrime)
            {
                if (prime % i == 0)
                {
                    isPrime = false;
                }
                else
                {
                    i++;
                }
            }
            return isPrime;
        }
    }
}
