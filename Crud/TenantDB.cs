using Dapper;

class TenantDB : DBConnection, ICrud<Tenant>
{
    public int Create(Tenant obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO tenants (full_name, email, adress)" +
        " VALUES (@FullName, @Email, Adress);";

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

        string query = "DELETE FROM tenants WHERE id = @id;";

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

    public List<Tenant> Read()
    {
        string query = "SELECT id AS Id, full_name AS FullName, email AS Email, adress AS Adress" +
        " FROM tenants;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Tenant>(query).ToList();
            return result;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public void Update(Tenant obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE tenants SET full_name = @FullName, email = @Email, adress = @Adress" +
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