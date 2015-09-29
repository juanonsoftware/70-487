using System;
using System.Threading;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessRecords();
            Console.WriteLine("Wait for the result...");
            Console.ReadLine();
        }

        static async void ProcessRecords()
        {
            var repository = new Repository();
            var records = await repository.CountRecords();
            Console.WriteLine("Records: " + records);
        }
    }
}
