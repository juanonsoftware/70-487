using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Repository
    {
        public async Task<int> CountRecordsAsync()
        {
            await Task.Factory.StartNew(PerformALongRunningTask);
            return 10;
        }

        private void PerformALongRunningTask()
        {
            Thread.Sleep(TimeSpan.FromSeconds(20));
        }
    }
}