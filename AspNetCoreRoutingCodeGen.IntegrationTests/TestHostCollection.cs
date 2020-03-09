using Xunit;

namespace AspNetCoreRoutingCodeGen.IntegrationTests
{
    [CollectionDefinition(Name)]
    public class TestHostCollection : ICollectionFixture<TestHostFixture>
    {
        public const string Name = nameof(TestHostCollection);
    }
}
