using AdoNet_MySQL_Demo.Lib.Models;

namespace AdoNet_MySQL_Demo.Lib.DB;

public class DataBase
{
    public AccountsDb TableAccounts { get; set; }
    public UsersDb TableUsers { get; set; }

    public DataBase()
    {
        TableAccounts = new AccountsDb();
        TableUsers = new UsersDb();
    }

    public void InsertAccountUser(Account account, User user)
    {
        TableAccounts.InsertAccount(account);
        TableUsers.InsertUser(user);
    }
}
