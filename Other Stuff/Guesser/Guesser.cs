using System.Diagnostics;

namespace Guesser
{
    public class Runner
    {
        private readonly string password;
        private readonly List<string> guessedKeys = new List<string>();
        private bool isGuessed = false;

        private readonly int length;

        public Runner(string password, int length)
        {
            this.password = password;
            this.length = length;
        }

        public TimeSpan Guesser()
        {
            return Guesser(1);
        }

        public TimeSpan Guesser(int threadCount)
        {
            Stopwatch stopwatch = new Stopwatch();
            if (threadCount == 0)
            {
                threadCount = 1;
                Thread.Sleep(500);
            }

            stopwatch.Start();
            for (int i = 0; i < threadCount; i++)
            {
                Thread thread = new Thread(() => guess(length));
                thread.Start();
            }

            while (!isGuessed)
            {
                Thread.Sleep(10);
            }
            stopwatch.Stop();

            TimeSpan ts;
            ts = stopwatch.Elapsed;

            return ts;
        }

        private void guess(int length)
        {
            while (!isGuessed)
            {
                string threadGuess = RNG.PasswordGenerator(length);

                if (!guessedKeys.Contains(threadGuess))
                {
                    guessedKeys.Add(threadGuess);
                    if (threadGuess == password)
                    {
                        isGuessed = true;
                    }
                }
            }
        }
    }

    public class RNG
    {
        public static string PasswordGenerator(int length)
        {
            string gpw = "";

            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                gpw += random.Next(0, 9);
            }

            return gpw;
        }
    }
}