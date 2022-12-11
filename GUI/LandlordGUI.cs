class LandlordGUI
{
    Controller inputController = new();

    public void MainMenu(Landlord activeLandlord)
    {
        while (true)
        {
            Console.Clear();

            string[] landlordMenuText = new string[]
            {
                "1.) Show all tenants and their rooms",
                "2.) Search by tenant",
                "3.) Search by room",
                "4.) Issue Conversations",
                "5.) Show this months bills [Not Implemented]",
                "R.) Return to Main Menu",
                "Q.) Quit"
            };
            foreach (var line in landlordMenuText)
            {
                Console.WriteLine(line);
            }
            var keyPress = Console.ReadKey(true);

            switch (keyPress.Key)
            {
                case ConsoleKey.D1:
                    ShowTenantsSubmenu();
                    break;
                case ConsoleKey.D2:
                    TenantSearchSubmenu();
                    break;
                case ConsoleKey.D3:
                    RoomSearchSubmenu();
                    break;
                case ConsoleKey.D4:
                    IssueConversationsSubmenu();
                    break;
                case ConsoleKey.D5:
                    ShowbillsSubmenu();
                    break;
                case ConsoleKey.R:
                    return;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    private void ShowTenantsSubmenu()
    {
        Manager manager = new();
        
    }

    private void TenantSearchSubmenu()
    {
        throw new NotImplementedException();
    }

    private void RoomSearchSubmenu()
    {
        throw new NotImplementedException();
    }

    private void IssueConversationsSubmenu()
    {
        throw new NotImplementedException();
    }

    private void ShowbillsSubmenu()
    {
        throw new NotImplementedException();
    }
}