using Dapper;

class MiscellaneousDB : DBConnection
{
    public List<SelectMapper> GetAllRoomsAndTenants()
    {
        string query = "SELECT r.id AS 'item1', t.full_name AS 'item2' FROM rooms_to_tenants rt" +
        " INNER JOIN rooms r ON r.id = rt.room_id" +
        " INNER JOIN tenants t ON t.id = rt.tenant_id;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<SelectMapper>(query).ToList();
            return result;
        }
        catch (System.InvalidOperationException)
        {
            return null;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public List<SelectMapper> GetMessagesWithNames(int conversationId)
    {
        var parameters = new { id = conversationId };

        string query = "SELECT m.id AS 'item1', m.message AS 'item2', t.full_name AS 'item3' FROM messages m" +
        " INNER JOIN tenants t ON t.id = m.tenant_id" +
        " WHERE m.conversation_id = @id;" +

        " SELECT m.id AS 'item1', m.message AS 'item2', l.full_name AS 'item3' FROM messages m" +
        " INNER JOIN landlords l ON l.id = m.landlord_id" +
        " WHERE m.conversation_id = @id;";

        using var connection = DBConnect();

        try
        {
            var multi = connection.QueryMultiple(query, parameters);
            var result = multi.Read<SelectMapper>().ToList();
            var result2 = multi.Read<SelectMapper>().ToList();

            result.AddRange(result2);
            result.Sort((x, y) => (int)x?.item1 - (int)y?.item1);

            return result;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    public List<SelectMapper> SelectByTenant(int id)
    {
        var parameters = new { id = id };

        string query = "SELECT r.id AS 'item1', t.full_name AS 'item2' FROM rooms_to_tenants rt" +
        " INNER JOIN rooms r ON r.id = rt.room_id" +
        " INNER JOIN tenants t ON t.id = rt.tenant_id" +
        " WHERE t.id = @id;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<SelectMapper>(query, parameters).ToList();
            return result;
        }
        catch (System.InvalidOperationException)
        {
            return null;
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public List<SelectMapper> SelectByRoom(int id)
    {
        var parameters = new { id = id };

        string query = "SELECT t.id AS 'item1', t.full_name AS 'item2' FROM rooms_to_tenants rt" +
        " INNER JOIN tenants t ON t.id = rt.tenant_id" +
        " WHERE rt.room_id = @id;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<SelectMapper>(query, parameters).ToList();
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
}