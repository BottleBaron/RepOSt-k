class Manager
{
    MiscellaneousDB miscDb = new();


    public List<SelectMapper> GetAllTenantsAndRooms()
    {
        List<SelectMapper> result = miscDb.GetAllRoomsAndTenants();
        
        return result;
    }

    public List<SelectMapper> SearchByTenant(int id)
    {
        List<SelectMapper> result = miscDb.SelectByTenant(id);

        return result;
    }

    public List<SelectMapper> SearchByRoom(int id)
    {
        List<SelectMapper> result = miscDb.SelectByRoom(id);

        return result;
    }
}