namespace StringNumbersCalculator
{
    public class Program
    {

        public static int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            var delimiter = ",";
            var numberString = numbers;

            if (numbers.StartsWith("//"))
            {
                var parts = numbers.Split('\n', 2);
                delimiter = parts[0].Substring(2);
                numberString = parts[1];
            }

            var separators = new[] { delimiter, "\n" };
            var nums = numberString.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToList();

            var negatives = nums.Where(n => n < 0).ToList();
            if (negatives.Any())
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
            }

            return nums.Sum();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Please input number string ");
            var input = Console.ReadLine();
            Console.WriteLine($"Sum of the input is {Add(input)}");
        }
    }
}
