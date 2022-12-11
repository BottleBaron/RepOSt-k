class LandlordManager
{
    ICrud<Landlord> landlordCaller;

    public LandlordManager(ICrud<Landlord> landlordDb)
    {
        landlordCaller = landlordDb;
    }

 
}