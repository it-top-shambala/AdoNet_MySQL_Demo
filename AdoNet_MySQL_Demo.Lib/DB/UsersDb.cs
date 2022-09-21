using AdoNet_MySQL_Demo.Lib.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace AdoNet_MySQL_Demo.Lib.DB;

public class UsersDb
{
    private readonly MySqlConnection _db;
    private readonly MySqlCommand _command;

    public UsersDb()
    {
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        _db = new MySqlConnection(DbConfig.Import("db.json").ToString());
        _command = new MySqlCommand { Connection = _db };
    }

    public IEnumerable<User> GetAllUsers()
    {
        _db.Open();
        const string SQL = "SELECT user_id, first_name, last_name FROM table_users";
        var users = _db.Query<User>(SQL);
        _db.Close();
        return users;
    }

    public User GetUserById(int id)
    {
        _db.Open();
        var sql = $"SELECT user_id, first_name, last_name FROM table_users WHERE user_id = {id}";
        var user = _db.QueryFirst<User>(sql);
        _db.Close();
        return user;
    }

    public void InsertUser(User user)
    {
        _db.Open();
        _command.CommandText =
            $"INSERT INTO table_users(first_name, last_name) VALUES ('{user.FirstName}', '{user.LastName}')";
        _command.ExecuteNonQuery();
        _db.Close();
    }
}
