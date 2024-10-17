using System.Diagnostics;

namespace SortingHell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to sorting Hell!");
            Console.WriteLine("------------------------");

            int aaa;
            bool sizeDefined = false;

            do
            {
                Console.WriteLine("How big should the Array be?");
                aaa = Utils.CheckToInt(Console.ReadLine());

                sizeDefined = Utils.CheckInts(aaa);
            } while (!sizeDefined);

            int[] arr = Utils.InitArray(aaa);
            Console.WriteLine("Initial Array has been created!");

            Task task1 = Task.Run(() => Sorters.BuggleSort(arr)); // launch BubbleSort in a new thread
            Task task2 = Task.Run(() => Sorters.SelectionSort(arr)); // launch SelectionSort in a new Thread
            Task task3 = Task.Run(() => Sorters.InsertionSort(arr)); // launch InsertionSort in a new Thread
            Task task4 = Task.Run(() => Sorters.QuickSortLauncher(arr)); // launch the QuickSort Launcher in a new thread, to Launch Quicksort.
            
            // Wait for all tasks to complete
            Task.WaitAll(task1, task2, task3, task4);

            Console.WriteLine();
            Console.WriteLine("All sorting methods have completed.");
        }
    }

    internal class Sorters
    {
        // Bubble Sort.
        internal static void BuggleSort(int[] input)
        {
            // Did you know, that I often press 'g' instead of 'b'?
            int c = 0;
            int[] a = new int[input.Length];
            input.CopyTo(a, 0);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = a.Length; i > 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (a[j - 1] > a[j])
                    {
                        int tmp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = tmp;
                        c ++;
                    }
                }
            }
            sw.Stop();

            Console.WriteLine("BubbleSort has concluded! It took {0} and needed {1} tries.", sw.Elapsed.Seconds, c);
        }

        // Insertion Sort Algorythm.
        internal static void InsertionSort(int[] input)
        {
            int c = 0;
            int[] a = new int[input.Length];
            input.CopyTo(a, 0);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 1; i < a.Length; i++)
            {
                int j = i;
                int v = a[i];

                while (j > 0 && a[j - 1] > v)
                {
                    a[j] = a[j - 1];
                    j--;
                    c++;
                }

                a[j] = v;
            }
            sw.Stop();

            TimeSpan ts = sw.Elapsed;

            Console.WriteLine("InsertionSort has concluded! It took {0} and needed {1} tries", ts.Seconds, c);
        }

        // SelectionSort Algorythm
        internal static void SelectionSort(int[] input) {
            int c = 0;
            int[] a = new int[input.Length];
            input.CopyTo(a, 0);
            
            int i, j, min, t;

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (i = 0; i < (a.Length - 1); i++) {
                min = i;
                for (j = i + 1; j < a.Length; j++) { 
                    if (a[j] < a[min])
                    {
                        min = j;
                    }
                }
                t = a[min];
                a[min] = t;
                a[i] = t;
                c++;
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("SelectionSort has concluded! It took {0} and needed {1} tries", ts.Seconds, c);
        }

        // The QuickSort Algorythm
        static void QuickSort(int[] arr, int left, int right, ref int c) {
            int i = left;
            int j = right;
            int tmp;

            int pivot = arr[ ( left + right ) / 2];

            while (i < j) {
                while (arr[i] < pivot)
                {
                    i++;
                }
                while (arr[j] > pivot) {
                    j--;
                }

                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                    c++;
                }
            }
            if (left < j) { 
                QuickSort(arr, left, j, ref c);
            }
            if (i < right)
            {
                QuickSort(arr, i, right, ref c);
            }
        }
        // Launcher for QuickSort
        internal static void QuickSortLauncher(int[] input) {
            int c = 0;
            int[] a = new int[input.Length];
            input.CopyTo(a, 0);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            QuickSort(a, 0, a.Length-1, ref c);
            sw.Stop();

            TimeSpan ts = sw.Elapsed;
            Console.WriteLine("QuickSort has concluded! It took {0} and needed {1} tries", ts, c);
        }
    }


    internal class Utils
    {
        internal static int[] InitArray(int size) // init the array
        {
            int[] arr = new int[size];

            Random r = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1000);
            }

            return arr;
        }

        public static void PrintArray(int[] arr) // 1D array printer
        {
            Console.Write("[ ");
            foreach (int element in arr)
            {
                Console.Write(element + " ");
            }
            Console.Write("]");

            Console.WriteLine();
        }


        // of course I copy those two methods. I don't do anything else with those.
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
    }
}
