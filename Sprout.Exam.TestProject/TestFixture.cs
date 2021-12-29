using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Sprout.Exam.TestProject
{
    public class TestFixture<TStartup> : IDisposable where TStartup : class
    {
        public readonly TestServer Server;
        private readonly HttpClient _client;
        public TestFixture()
        {
            var builder = new WebHostBuilder()
                .UseContentRoot($"..\\..\\..\\..\\..\\Sprout.Exam.WebApp\\")
                .UseStartup<TStartup>();
            Server = new TestServer(builder);
            _client = new HttpClient();
        }

        public void Dispose()
        {
            _client.Dispose();
            Server.Dispose();
        }
    }
}
