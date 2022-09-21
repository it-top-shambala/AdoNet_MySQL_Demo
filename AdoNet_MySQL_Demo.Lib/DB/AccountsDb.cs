using AdoNet_MySQL_Demo.Lib.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace AdoNet_MySQL_Demo.Lib.DB;

public class AccountsDb
{
    private readonly MySqlConnection _db;
    private readonly MySqlCommand _command;

    public AccountsDb()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        _db = new MySqlConnection(DbConfig.Import("db.json").ToString());
        _command = new MySqlCommand { Connection = _db };
    }

    public IEnumerable<Account> GetAllAccounts()
    {
        _db.Open();
        const string SQL = "SELECT account_id, login, password, is_delete FROM table_accounts";
        var accounts = _db.Query<Account>(SQL);
        _db.Close();
        return accounts;
    }

    public Account GetAccountById(int id)
    {
        _db.Open();
        var sql = $"SELECT account_id, login, password, is_delete FROM table_accounts WHERE account_id = {id}";
        var account = _db.QueryFirst<Account>(sql);
        _db.Close();
        return account;
    }

    public void InsertAccount(Account account)
    {
        _db.Open();
        _command.CommandText =
            $"INSERT INTO table_accounts(login, password) VALUES ('{account.Login}', '{account.Password}')";
        _command.ExecuteNonQuery();
        _db.Close();
    }

    public void UpdateAccount(Account account)
    {
        _db.Open();
        _command.CommandText =
            $"UPDATE table_accounts SET login = '{account.Login}', password = '{account.Password}' WHERE account_id = {account.Id}";
        _command.ExecuteNonQuery();
        _db.Close();
    }

    public void DeleteAccount(Account account)
    {
        _db.Open();
        _command.CommandText = $"UPDATE table_accounts SET is_delete = 1 WHERE account_id = {account.Id}";
        _command.ExecuteNonQuery();
        _db.Close();
    }
}
