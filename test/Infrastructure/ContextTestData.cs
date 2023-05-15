namespace GoSupply.Test.Infrastructure;

public class ContextTestData
{
    public static IEnumerable<object[]> ConnectionSuccess =>
     new List<object[]>
     {
        new object[]
        {
            "Server=(localdb)\\mssqllocaldb;Database=GoSupplyDb;Trusted_Connection=True;MultipleActiveResultSets=true"
        }
     };
}
