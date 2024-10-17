namespace TextRepeater
{
    internal class TextOuter
    {
        static void Main(string[] args)
        {
            string lang = "";
            if (args.Length <= 1)
            {
                Console.WriteLine("You didn't provide any arguments.");
                Environment.Exit(1);
            }
            if (!(args[0] == "en" || args[0] == "de" || args[0] == "lat" || args[0] == "lolcat"))
            {
                Console.WriteLine("Check your input again.");
                Console.WriteLine("Your Options are: en, de, lat, lolcat");
                Environment.Exit(1);
            }
            else
            {
                lang = args[0];
            }

            int times = 0;
            if (int.TryParse(args[1], out times))
            {
                string message = Message(lang);
                Outer(message, times);
            }
            else
            {
                Console.WriteLine("Your times argument was wrong.");
            }

        }

        static void Outer(string text, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine(text);
            }
        }


        static string Message(string lang)
        {
            switch (lang)
            {
                default: return "I have no idea how you got here.";
                case "en": return "Hello, World!";
                case "de": return "Hallo Welt!";
                case "lat": return "Salve Mundo";
                case "lolcat": return "Hai world!";

            }
        }
    }
}