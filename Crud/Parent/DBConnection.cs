using Dapper;
using MySqlConnector;

internal abstract class DBConnection
{
    //Parent class that handles the server and user/pw for the database connection
    public MySqlConnection DBConnect()
    {
        var connection = new MySqlConnection("Server=localhost;Database=repostök;Uid=root;");
        return connection;
    }
}