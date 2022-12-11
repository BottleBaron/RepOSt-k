class TenantManager
{
    ICrud<Tenant> tenantCaller;

    public TenantManager(ICrud<Tenant> tenantDb)
    {
        tenantCaller = tenantDb;
    }


}