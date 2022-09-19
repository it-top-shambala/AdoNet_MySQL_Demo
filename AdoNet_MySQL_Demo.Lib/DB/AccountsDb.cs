using AdoNet_MySQL_Demo.Lib.Models;
using MySql.Data.MySqlClient;

namespace AdoNet_MySQL_Demo.Lib.DB;

public class AccountsDb
{
    private readonly MySqlConnection _db;
    private readonly MySqlCommand _command;

    public AccountsDb()
    {
        _db = new MySqlConnection(DbConfig.Import("db.json").ToString());
        _command = new MySqlCommand {Connection = _db};
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        var accounts = new List<Account>();
        _db.Open();

        _command.CommandText = "SELECT account_id, login, password, is_delete FROM table_accounts";
        var result = _command.ExecuteReader();
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

        _command.CommandText = $"SELECT account_id, login, password, is_delete FROM table_accounts WHERE account_id = {id}";
        var result = _command.ExecuteReader();
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

    public void InsertAccount(Account account)
    {
        _db.Open();
        _command.CommandText = $"INSERT INTO table_accounts(login, password) VALUES ('{account.Login}', '{account.Password}')";
        _command.ExecuteNonQuery();
        _db.Close();
    }

    public void UpdateAccount(Account account)
    {
        _db.Open();
        _command.CommandText = $"UPDATE table_accounts SET login = '{account.Login}', password = '{account.Password}' WHERE account_id = {account.Id}";
        _command.ExecuteNonQuery();
        _db.Close();
    }

    public void DeleteAccount(Account account)
    {
        _db.Open();
        _command.CommandText = $"UPDATE table_accounts SET is_delete = {account.IsDelete} WHERE account_id = {account.Id}";
        _command.ExecuteNonQuery();
        _db.Close();
    }
}
