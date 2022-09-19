using System.Text.Json;

namespace AdoNet_MySQL_Demo.Lib.DB;

public record DbConfig
{
    public string Server { get; set; }
    public string DataBase { get; set; }
    public string User { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return $"Server={Server};Database={DataBase};Uid={User};Pwd={Password};";
    }

    public static DbConfig Import(string path)
    {
        var json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<DbConfig>(json);
    }
}
