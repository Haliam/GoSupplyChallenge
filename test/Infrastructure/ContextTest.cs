namespace GoSupply.Test.Infrastructure
{
    public class ContextTest
    {
        [Theory]
        [MemberData(nameof(ContextTestData.ConnectionSuccess), MemberType = typeof(ContextTestData))]
        public void ConnectionSuccess(string connectionString)
        {
            new NotImplementedException();
        }
    }
}
