namespace Datentypen
{
    internal class datatypes
    {
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;

            int c = a + b;
            hell();
            Console.WriteLine($"Ergebnis: {c}");

            double d = 10.0;
            float f = 1.0f;
            decimal dec = 10.2m;
            bool bb = true;
            char cc = 'S'; // standard: UTF-16
            string hello = "Hello";
            string hello1 = "";
            hello1 += hello + " World!";

            Console.WriteLine($"Message: {hello1}");
            
            float weirdFloating = 0.1f + 0.2f;
            Console.WriteLine(weirdFloating);
        }

        static void hell()
        {
            Console.WriteLine("Welcome to hell.");
        }
    }
}