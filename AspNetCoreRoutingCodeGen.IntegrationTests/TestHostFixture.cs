using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;

namespace AspNetCoreRoutingCodeGen.IntegrationTests
{
    public sealed class TestHostFixture : IDisposable
    {
        private readonly WebApplicationFactory<Subject.Startup> _appFactory;

        public HttpClient AppClient => _appFactory.CreateClient();

        public TestHostFixture()
        {
            _appFactory = new WebApplicationFactory<Subject.Startup>();
        }

        public void Dispose()
        {
            _appFactory.Dispose();
        }
    }
}
