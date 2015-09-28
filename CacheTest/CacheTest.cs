using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.Caching;

namespace CacheTest
{
    [TestClass]
    public class CacheTest
    {
        [TestMethod]
        public void AddWillNotReplaceCachedData()
        {
            // Arrange
            var date1 = DateTime.Now;
            var cache = MemoryCache.Default;
            var policy = new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(1)) };
            cache.Add("date", date1, policy);

            // Act
            var date2 = DateTime.Now.AddMinutes(10);
            cache.Add("date", date2, policy);

            // Assert
            var dateInCache = cache.Get("date");
            Assert.AreEqual(date1, dateInCache);
        }

        [TestMethod]
        public void SetWillReplaceCachedData()
        {
            // Arrange
            var date1 = DateTime.Now;
            var cache = MemoryCache.Default;
            var policy = new CacheItemPolicy() { AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(1)) };
            cache.Set("date", date1, policy);

            // Act
            var date2 = DateTime.Now.AddMinutes(10);
            cache.Set("date", date2, policy);

            // Assert
            var dateInCache = cache.Get("date");
            Assert.AreEqual(date2, dateInCache);
        }
    }
}
