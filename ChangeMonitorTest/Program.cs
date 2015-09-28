using System;
using System.IO;
using System.Runtime.Caching;
using System.Threading;
using System.Web;

namespace ChangeMonitorTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //var watcher = new FileSystemWatcher(Path.Combine(Directory.GetCurrentDirectory(), "../../"));
            //watcher.Changed += watcher_Changed;
            //watcher.NotifyFilter = NotifyFilters.Size;
            //watcher.Filter = "*.*";
            //watcher.EnableRaisingEvents = true;

            var cache = MemoryCache.Default;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../App.config");

            cache.Add(filePath, File.ReadAllText(filePath), GetCacheItemPolicy());

            var count = 0;
            while (true)
            {
                var value = cache.Get(filePath);
                Console.WriteLine(value);

                if (string.IsNullOrWhiteSpace((string)value))
                {
                    cache.Add(filePath, File.ReadAllText(filePath), GetCacheItemPolicy());
                }

                count += 1;
                Thread.Sleep(100);

                if (count > 100)
                {
                    break;
                }
            }

            Console.ReadLine();
        }

        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine(e.Name + " " + e.FullPath + " " + e.ChangeType);
        }

        static CacheItemPolicy GetCacheItemPolicy()
        {
            var cachePolicy = new CacheItemPolicy()
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddHours(1))
            };

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "../../App.config");
            var changeMonitor = new HostFileChangeMonitor(new string[]
            {
                filePath
            });

            //changeMonitor.NotifyOnChanged(state =>
            //{
            //    Console.WriteLine("Has Changed");
            //    cache.Add(filePath, File.ReadAllText(filePath), cachePolicy);
            //});

            cachePolicy.ChangeMonitors.Add(changeMonitor);

            return cachePolicy;
        }
    }
}
