using System;

namespace ExceptionHandlingDemo
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(string message) : base(message) { }
    }

    public class Program
    {
        public static void ValidateNumber(int number)
        {
            if (number < 0)
                throw new NegativeNumberException("Number cannot be negative.");

            if (number == 0)
                throw new ArgumentException("Number cannot be zero.");

            Console.WriteLine($"Validated number: {number}");
        }

        public static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter a number: ");
                int input = int.Parse(Console.ReadLine());

                ValidateNumber(input);
            }
            catch (NegativeNumberException ex)
            {
                Console.WriteLine($"Custom Exception Caught: {ex.Message}");
                throw;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument Exception Caught: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Input format is invalid.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Exception Caught: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("This block always executes (cleanup, etc).");
            }

#if DEBUG
            Console.WriteLine("DEBUG MODE: Additional debug info could go here.");
#endif

#if RELEASE
            Console.WriteLine("RELEASE MODE: Optimized for performance.");
#endif
        }
    }
}
