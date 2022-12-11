using Dapper;

class ConversationDB : DBConnection, ICrud<Conversation>, ISelectSingle<Conversation>, ISelectWhere<Conversation>
{
    public int Create(Conversation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO issue_conversations (tenant_id, title)" +
        "VALUES (@TenantId, @Title); SELECT LAST_INSERT_ID();";

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

        string query = "DELETE FROM issue_conversations WHERE id = @id;";

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

    public List<Conversation> Read()
    {
        string query = "SELECT id AS 'Id', tenant_id AS 'TenantId', title AS 'Title', is_archived AS 'IsArchived'" +
        "FROM issue_conversations;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Conversation>(query).ToList();
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

    // TODO: use this to only show tenants convos started by themselves
    public List<Conversation> SelectWhere(int id)
    {
        var parameters = new { id = id };

        string query = "SELECT id AS 'Id', tenant_id AS 'TenantId', title AS 'Title', is_archived AS 'IsArchived'" +
        "FROM issue_conversations WHERE tenant_id = @id;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Conversation>(query, parameters).ToList();
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

    public Conversation SelectSingle(int id)
    {
        var parameters = new { id = id };

        string query = "SELECT id AS 'Id', tenant_id AS 'TenantId', title AS 'Title', is_archived AS 'IsArchived'" +
        "FROM issue_conversations WHERE id = @id;";

        using var connection = DBConnect();

        try
        {
            var result = connection.QuerySingle<Conversation>(query, parameters);
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

    public void Update(Conversation obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE issue_conversations SET tenant_id = @TenantId, title = @Title, is_archived = @IsArchived" +
        " WHERE id = @Id;";

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