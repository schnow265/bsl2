namespace Pointer
{
    internal class Program
    {
        static void Swap(ref int x, ref int y)
        {
            int h = x;
            x = y;
            y = h;
        }

        static unsafe void UnsafeSwap (int* x, int* y)
        {
            int h = *x;

            *x = *y;
            *y = h;
        }

        static unsafe void Main(string[] args)
        {
            //int x = 10;
            //int* p = &x;

            //Console.WriteLine($"x={x}");
            //Console.WriteLine("p={0:X}", (long) p);
            
            //int** p2 = &p;

            //Console.WriteLine("p2={0:X}",(long) p2);

            int y = 5;
            int z = 10;

            UnsafeSwap(&y, &z);
            
            Console.WriteLine(y);
            Console.WriteLine(z);
        }
    }
}
