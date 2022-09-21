using AdoNet_MySQL_Demo.Lib.DB;
using Xunit;

namespace AdoNet_MySQL_Demo.Lib.Test;

public class DbConfigTest
{
    private readonly DbConfig _expectedConfig;

    public DbConfigTest()
    {
        _expectedConfig = new DbConfig
        {
            Server = "localhost", DataBase = "database", User = "user", Password = "password"
        };
    }

    [Fact]
    public void ImportTest()
    {
        var actualConfig = DbConfig.Import("db.json");

        Assert.Equal(_expectedConfig, actualConfig);
    }

    [Fact]
    public void ToStringTest()
    {
        var expected = _expectedConfig.ToString();
        var actual = DbConfig.Import("db.json").ToString();

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ToStringRegExpTest()
    {
        var str = DbConfig.Import("db.json").ToString();
        const string REGEX = "Server=[A-Za-z]+;Database=[A-Za-z]+;Uid=[A-Za-z]+;Pwd=[A-Za-z]+;";
        Assert.Matches(REGEX, str);
    }
}
