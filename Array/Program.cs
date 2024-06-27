namespace Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestArray();
            
        }

        static void Foo(int x) {

            x = 100;
        }

        static void InitArray(int[] arr)
        {
            Random r = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1000);
            }
        }

        static void TestArray()
        {
            int[] arr = null; // Ohne Speicher

            arr = new int[10];

            Console.WriteLine("arr");
            InitArray(arr);

            arr[2] = 100;

            Console.WriteLine(arr[2]);
        }

        static void TestArray2()
        {
            int[,] arr = null;

            arr = new int[3,2];

            InitArray(arr);
        }

        static void InitArray(int[,] arr)
        {
            Random r = new Random();

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = r.Next(1000) + 1;
                }
            }
        }
    }
}
