using AdoNet_MySQL_Demo.Lib.Models;
using MySql.Data.MySqlClient;

namespace AdoNet_MySQL_Demo.Lib.DB;

public class AccountsDb
{
    private MySqlConnection _db;

    public AccountsDb()
    {
        _db = new MySqlConnection(DbConfig.Import("db.json").ToString());
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        var accounts = new List<Account>();
        _db.Open();

        const string SQL = "SELECT account_id, login, password, is_delete FROM table_accounts";
        var command = new MySqlCommand(SQL, _db);
        var result = command.ExecuteReader();
        if (result.HasRows)
        {
            while (result.Read())
            {
                accounts.Add(new Account
                {
                    Id = result.GetInt32("account_id"),
                    Login = result.GetString("login"),
                    Password = result.GetString("password"),
                    IsDelete = result.GetBoolean("is_delete")
                });
            }
        }

        _db.Close();

        return accounts;
    }

    public Account? GetAccountById(int id)
    {
        Account account = null;
        _db.Open();

        var sql = $"SELECT account_id, login, password, is_delete FROM table_accounts WHERE account_id = {id}";
        var command = new MySqlCommand(sql, _db);
        var result = command.ExecuteReader();
        if (result.HasRows)
        {
            result.Read();
            account = new Account
            {
                Id = result.GetInt32("account_id"),
                Login = result.GetString("login"),
                Password = result.GetString("password"),
                IsDelete = result.GetBoolean("is_delete")
            };
        }

        _db.Close();

        return account;
    }
}
