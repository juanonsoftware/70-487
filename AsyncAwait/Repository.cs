using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Repository
    {
        public async Task<int> CountRecords()
        {
            await Task.Factory.StartNew(() => Thread.Sleep(TimeSpan.FromSeconds(20)));
            return 10;
        }
    }
}