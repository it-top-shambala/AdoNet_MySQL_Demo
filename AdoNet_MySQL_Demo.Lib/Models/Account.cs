namespace AdoNet_MySQL_Demo.Lib.Models;

public class Account
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsDelete { get; set; }
}
