using System.Diagnostics;

namespace SortingHell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to sorting Hell!");
            Console.WriteLine("------------------------");
            int[] arr = Utils.InitArray(10_000);
            Console.WriteLine("Initial Array has been created!");

            Task task1 = Task.Run(() => Sorters.BuggleSort(arr));
            Task task2 = Task.Run(() => Sorters.SelectionSort(arr));
            Task task3 = Task.Run(() => Sorters.InsertionSort(arr));
            Task task4 = Task.Run(() => Sorters.QuickSortLauncher(arr));
            
            // Wait for all tasks to complete
            Task.WaitAll(task1, task2, task3, task4);

            Console.WriteLine();
            Console.WriteLine("All sorting methods have completed.");
        }
    }

    internal class Sorters
    {
        internal static void BuggleSort(int[] input)
        {
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

            Console.WriteLine("BubbleSort has concluded! It took {0} and needed {1} tries.", sw.Elapsed, c);
        }

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

            Console.WriteLine("InsertionSort has concluded! It took {0} and needed {1} tries", ts, c);
        }

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
            Console.WriteLine("SelectionSort has concluded! It took {0} and needed {1} tries", ts, c);
        }

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
        internal static int[] InitArray(int size)
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
    }
}
