using MySql.Data.MySqlClient;
using Testcontainers.MySql;

namespace Tienda.Api.IntegrationTests;

public class MySqlConnectivityTests
{
    [Fact]
    [Trait("Category", "Docker")]
    public async Task MySql_84_accepts_a_query_using_the_oracle_driver()
    {
        await using var container = new MySqlBuilder("mysql:8.4.6").Build();
        await container.StartAsync(TestContext.Current.CancellationToken);

        await using var connection = new MySqlConnection(container.GetConnectionString());
        await connection.OpenAsync(TestContext.Current.CancellationToken);
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT VERSION()";
        var version = (string?)await command.ExecuteScalarAsync(TestContext.Current.CancellationToken);

        Assert.NotNull(version);
        Assert.StartsWith("8.4.", version);
    }
}
