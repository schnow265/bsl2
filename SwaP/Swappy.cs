namespace SwaP
{
    internal class Swappy
    {

        static int a;
        static int b;
        static void Main(string[] args)
        {
            if (args.Length <= 1)
            {
                Console.WriteLine("Please give two numbers as an argument!");
            }
            else
            {
                if (int.TryParse(args[0], out a) && int.TryParse(args[1], out b))
                {
                    //Swap Nubers
                    int tmp1 = a;
                    int tmp2 = b;
                    b = tmp1;
                    a = tmp2;

                    // Print Numbers
                    Console.WriteLine($"a: {a}; b: {b}");
                }
                else
                {
                    Console.WriteLine("Not an Int! - Wrong parameter!");
                }
            }
        }
    }
}