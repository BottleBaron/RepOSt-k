class LandlordGUI
{
    private Controller inputController = new();
    private Landlord activeLandlord;

    public void MainMenu(Landlord activeLandlord)
    {
        this.activeLandlord = activeLandlord;

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
        Console.Clear();

        Manager manager = new();
        List<SelectMapper> listOfTenantsAndRooms = manager.GetAllTenantsAndRooms();

        if (listOfTenantsAndRooms != null)
        {
            Console.WriteLine("Rooms: | Tenants:");
            foreach (var row in listOfTenantsAndRooms)
            {
                Console.WriteLine($"     {row.T1} | {row.T2}");
            }
        }
        Console.ReadKey();
    }

    private void TenantSearchSubmenu()
    {
        Console.Clear();
        Console.Write("Please enter a Tenant id for search:");
        string? input = Console.ReadLine();

        int inputId = inputController.TryIntConversion(input);

        Manager manager = new();
        if (!inputController.CheckIfNegative(inputId) && inputId != 0)
        {
            List<SelectMapper>? roomsByTenant = manager.SearchByTenant(inputId);

            if (roomsByTenant != null)
            {
                Console.WriteLine($"-< ROOMS ASSIGNED TO: {roomsByTenant[0].T2} >-");
                foreach (var room in roomsByTenant)
                {
                    Console.Write($" [{room.T1}] ");
                }
                Console.WriteLine("");
            }
        }
        Console.ReadKey();
    }

    private void RoomSearchSubmenu()
    {
        Console.Clear();
        Console.Write("Please enter a Room id for search:");
        string? input = Console.ReadLine();

        int inputId = inputController.TryIntConversion(input);

        Manager manager = new();
        if (!inputController.CheckIfNegative(inputId) && inputId != 0)
        {
            List<SelectMapper>? tenantsByRoom = manager.SearchByRoom(inputId);

            if (tenantsByRoom != null)
            {
                Console.WriteLine($"-< TENANTS ASSIGNED TO: ROOM {inputId}>-");
                foreach (var tenant in tenantsByRoom)
                {
                    Console.WriteLine($" [ID: {tenant.T1} | {tenant.T2}] ");
                }
                Console.WriteLine("");
            }
        }
        Console.ReadKey();
    }

    private void IssueConversationsSubmenu()
    {
        Console.Clear();
        ConversationManager conversationManager = new();
        List<Conversation>? listOfConversations = conversationManager.GetNonArchivedConvos();

        if (listOfConversations != null)
        {
            TenantDB tenantDB = new();
            foreach (var conversation in listOfConversations)
            {
                Tenant tenantNameGetter = tenantDB.SelectSingle(conversation.TenantId);
                Console.WriteLine($"{conversation.Id}). {conversation.Title} | {tenantNameGetter.FullName} \n");
            }
        }
        Console.Write("Please select a conversation:");
        string? input = Console.ReadLine();

        int inputId = inputController.TryIntConversion(input);

        ConversationGUI chosenConversation;
        if (!inputController.CheckIfNegative(inputId) && inputId != 0)
        {
            chosenConversation = new(inputId);
            bool success = chosenConversation.EnterConversation(true, activeLandlord.Id);
            if (!success)
            {
                Console.WriteLine("Something went wrong trying to initialize messages...");
                Console.ReadKey();
                return;
            }
        }
    }

    private void ShowbillsSubmenu()
    {
    }
}