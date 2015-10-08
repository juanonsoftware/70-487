using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApiTest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get(int id)
        {
            new PushStreamContent((s, h, t) =>
            {

            });

            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            HttpClient httpClient1 = new HttpClient();
            HttpClient httpClient2 = new HttpClient();
            Task.WaitAll(new Task[]
            {
                httpClient1.GetAsync(""),
                httpClient2.GetAsync("")
            });
        }

        [HttpGet]
        public async Task<string> DownloadMicrosoftSite()
        {
            return await GetContent();
        }

        private async Task<string> GetContent()
        {
            HttpClient httpClient = new HttpClient();
            var r = httpClient.PostAsync("", 1, new JsonMediaTypeFormatter());

            var r2 = await httpClient.GetAsync("");
            r2.EnsureSuccessStatusCode();

            var client = new WebClient();
            var result = await client.DownloadStringTaskAsync(new Uri("http://www.microsoft.com/"));
            Thread.Sleep(3000);
            return result;
        }
    }
}