class Controller
{

    public int TryIntConversion(string input)
    {
        if(!String.IsNullOrEmpty(input))
        {
            if(Int32.TryParse(input, out int result)) return result;
        }
        return 0;
    }

    public bool CheckIfNegative(int input)
    {
        if (input < 0) return true;
        return false;
    }

    public Landlord TryLogin(string loginName, string password)
    {
        ICrud<Landlord> landlordCaller;
        landlordCaller = new LandlordDB();
        List<Landlord> landLords = landlordCaller.Read();

        foreach (var item in landLords)
        {
            if (item.LoginName == loginName && item.Password == password)
            {
                return item;
            }
        }
        return null;
    }
    public Tenant TryLogin(int id)
    {
        ICrud<Tenant> tenantCaller;
        tenantCaller = new TenantDB();
        List<Tenant> tenants = tenantCaller.Read();

        foreach (var item in tenants)
        {
            if (item.Id == id)
            {
                return item;
            }
        }
        return null;
    }
}