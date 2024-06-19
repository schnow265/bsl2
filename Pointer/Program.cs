namespace Pointer
{
    internal class Program
    {
        static unsafe void Main(string[] args)
        {
            int x = 10;
            int* p = &x;

            Console.WriteLine($"x={x}");
            Console.WriteLine("p={0:X}", (long) p);
            
            int** p2 = &p;

            Console.WriteLine("p2={0:X}",(long) p2);


            int* p3 = Foo();
            Console.WriteLine(*p3);

            Thread.Sleep(1000);

            Console.WriteLine("p3={0:X}", (long) p3);
            Console.WriteLine(*p3);
        }

        static unsafe int* Foo()
        {
            int x = 5;
            return &x;
        }
    }
}
