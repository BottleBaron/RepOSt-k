using Dapper;

class LandlordDB : DBConnection, ICrud<Landlord>
{
    public int Create(Landlord obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO landlords (full_name, login_name, password)" +
        " VALUES(@FullName, LoginName, PassWord)";

        using var connection = DBConnect();

        try
        {
            var identity = connection.ExecuteScalar<int>(query, parameters);
            return identity;
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public void Delete(int id)
    {
        var parameters = new DynamicParameters();

        string query = "DELETE FROM landlords WHERE id = @id";

        using var connection = DBConnect();

        try
        {
            connection.Execute(query, parameters);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public List<Landlord> Read()
    {
        string query = "SELECT id AS 'Id', full_name AS 'FullName', login_name AS 'LoginName'," +
        " password AS 'Password' FROM landlords";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Landlord>(query).ToList();
            return result;
        }
        catch(InvalidOperationException)
        {
            return null;
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public void Update(Landlord obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE landlords SET full_name = @FullName, login_name = LoginName, password = Password" + 
        " WHERE id = @Id";

        using var connection = DBConnect();

        try
        {
            connection.Execute(query, parameters);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}