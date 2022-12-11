internal class TestGround
{
    MiscellaneousDB miscDb = new();

    public TestGround()
    {
        Console.Clear();

        // FIX invalid operation exc.

        List<Tuple<int, string>> allRoomsandtenants = miscDb.ReadRoomsWithTenants();
        if (allRoomsandtenants != null)
        {
            foreach (var tuple in allRoomsandtenants)
            {
                Console.WriteLine(tuple.Item1 + "|" + tuple.Item2);
            }
        }


        Environment.Exit(0);
    }
}