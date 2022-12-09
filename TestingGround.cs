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
            Console.WriteLine(row.item1 + "|" + row.item2);
        }


        // Messages with names
        List<SelectMapper> selectedMessages = miscDb.GetMessagesWithNames(1);

        foreach (var message in selectedMessages)
        {
            Console.WriteLine(message.item3 + ": " + message.item2 + "\n");
        }


        // Search by tenant
        List<SelectMapper> roomsByTenant = miscDb.SelectByTenant(1);

        Console.WriteLine($"-< ROOMS ASSIGNED TO: {roomsByTenant[0].item2} >-");
        foreach (var room in roomsByTenant)
        {
            Console.Write($" [{room.item1}] ");
        }
        Console.WriteLine("");

        List<SelectMapper> tenantsByRoom = miscDb.SelectByRoom(3);

        Console.WriteLine($"-< TENANTS ASSIGNED TO: ROOM {tenantsByRoom[0].item1}>-");
        foreach (var tenant in tenantsByRoom)
        {
            Console.Write($" [{tenant.item2}] ");
        }
        Console.WriteLine("");

        Environment.Exit(0);
    }


}