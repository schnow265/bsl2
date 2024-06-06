class SumOfIntegers
{
    static void Main()
    {
        // Prompt the user to enter an integer
        Console.Write("Enter an integer: ");
        // Read the input and convert it to an integer
        int n = int.Parse(Console.ReadLine());

        // Initialize the sum to 0
        int sum = 0;

        // Loop from 1 to n and calculate the sum
        for (int i = 1; i <= n; i++)
        {
            sum += i;
        }

        // Output the result
        Console.WriteLine($"The sum of integers from 1 to {n} is {sum}");
    }
}