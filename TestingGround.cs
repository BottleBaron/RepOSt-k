using Dapper;

class TestingGround : DBConnection
{
    MiscellaneousDB miscDb = new();

    public TestingGround()
    {
        Console.Clear();

        // All rooms and their tenants
        List<SelectMapper> selectedValues = miscDb.GetAllRoomsAndTenants();

        foreach (var row in selectedValues)
        {
            Console.WriteLine(row.T1 + "|" + row.T2);
        }


        // Messages with names
        List<SelectMapper> selectedMessages = miscDb.GetMessagesWithNames(1);

        foreach (var message in selectedMessages)
        {
            Console.WriteLine(message.T3 + ": " + message.T2 + "\n");
        }


        // Search by tenant
        List<SelectMapper> roomsByTenant = miscDb.SelectByTenant(1);

        Console.WriteLine($"-< ROOMS ASSIGNED TO: {roomsByTenant[0].T2} >-");
        foreach (var room in roomsByTenant)
        {
            Console.Write($" [{room.T1}] ");
        }
        Console.WriteLine("");

        List<SelectMapper> tenantsByRoom = miscDb.SelectByRoom(3);

        Console.WriteLine($"-< TENANTS ASSIGNED TO: ROOM {tenantsByRoom[0].T1}>-");
        foreach (var tenant in tenantsByRoom)
        {
            Console.Write($" [{tenant.T2}] ");
        }
        Console.WriteLine("");

        Environment.Exit(0);
    }


}