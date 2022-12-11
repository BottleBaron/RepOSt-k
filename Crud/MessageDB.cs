using Dapper;

class MessageDB : DBConnection, ICrud<Message>, ISelectWhere<Message>
{
    public int Create(Message obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO messages (conversation_id, tenant_id, landlord_id, message)" +
        " VALUES (@ConversationId, @TenantId, @LandlordId, @Message_); SELECT LAST_INSERT_ID();";

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

        string query = "DELETE FROM messages WHERE id = @id";

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

    public List<Message> Read()
    {
        string query = "SELECT id AS Id, conversation_id AS ConversationId, tenant_id AS TenantId," +
        " landlord_id AS LandlordId, message AS Message_ FROM messages;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Message>(query).ToList();
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

    public void Update(Message obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE messages SET conversation_id = @ConversationId, tenant_id = @TenantId," +
        " landlord_id = @LandlordId, message = @Message_;";

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

    List<Message> ISelectWhere<Message>.SelectWhere(int conversation_id)
    {
        string query = "SELECT id AS 'Id', conversation_id AS 'ConversationId', tenant_id AS 'TenantId'," +
        " landlord_id AS 'LandlordId', message AS 'Message_' FROM messages WHERE conversation_id = @ conversationId;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Message>(query).ToList();
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
}