using System;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessDbAsync();
            Console.WriteLine("Wait for the result...");
            Console.ReadLine();
        }

        static async void ProcessDbAsync()
        {
            var repository = new Repository();
            var records = await repository.CountRecordsAsync();
            Console.WriteLine("Records: " + records);
        }
    }
}
