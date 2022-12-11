using Dapper;

internal class BillDB : DBConnection, ICrud<Bill>
{
    public int Create(Bill obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "INSERT INTO bills" +
        " (tenant_id, room_id, landlord_id, bill_date, payment_due_date, ocr_number, price, paid_date)" + 
        " VALUES (@Id, @TenantId, @RoomId, @LandlordId, @BillDate, @PaymentDueDate, @OcrNumber, @Price, @idDate);" +
        " SELECT LAST_INSERT_ID();";

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
 
        string query = "DELETE FROM bills WHERE id = @id;";

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

    public List<Bill> Read()
    {
        string query = "SELECT id AS 'Id', tenant_id AS 'TenantId', room_id AS 'RoomId', landlord_id AS 'LandlordId'," +
        " bill_date AS 'BillDate', payment_due_date AS 'PaymentDueDate', ocr_number AS 'OcrNumber', price AS 'Price'," +
        " paid_date AS 'PaidDate' FROM bills;";

        using var connection = DBConnect();

        try
        {
            var result = connection.Query<Bill>(query).ToList();
            return result;
        }
        catch(System.InvalidOperationException)
        { 
            return null;
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }

    public void Update(Bill obj)
    {
        var parameters = new DynamicParameters(obj);

        string query = "UPDATE bills SET tenant_id = @TenantId, room_id = @RoomId, landlord_id = @LandlordId," +
        " bill_date = @BillDate, payment_due_date = @PaymentDueDate, ocr_number = @OcrNumber, price = @Price," + 
        " paid_date = @PaidDate WHERE id = @Id;";

        using var connection = DBConnect();

        try
        {
            var identity = connection.ExecuteScalar<int>(query, parameters);
        }
        catch (System.Exception e)
        {
            throw e;
        }
    }
}