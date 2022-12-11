using Dapper;

class RoomDB : DBConnection, ICrud<Room>
{
    public int Create(Room obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO rooms (rent_per_month) VALUES (@RentPerMonth)";

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
        var parameters = new DynamicParameters(id);

        string query = "DELETE FROM rooms WHERE id = @id";

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

    public List<Room> Read()
    {
        string query = "SELECT id AS Id, rent_per_month AS RentPerMonth FROM rooms";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Room>(query).ToList();
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

    public void Update(Room obj)
    {
        throw new NotImplementedException();
    }
}