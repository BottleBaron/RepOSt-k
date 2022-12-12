class TenantGUI
{
    Controller inputController = new();

    public void MainMenu(Tenant activeTenant)
    {
        Console.Clear();

        string[] tenantMenuText = new string[]
        {
            "1.) Issue Conversations",
            "2.) Pay this months bill [Not Implemented]",
            "3.) Sign up for a new room [Not Implemented]",
            "4.) Remove yourself from a room [Not Implemented]",
            "R.) Return to Main Menu",
            "Q.) Quit"
        };
        foreach (var line in tenantMenuText)
        {
            Console.WriteLine(line);
        }
        var keyPress = Console.ReadKey(true);

        switch (keyPress.Key)
        {
            case (ConsoleKey.D1):
                IssueConversationsSubmenu(activeTenant.Id);
                break;
            case (ConsoleKey.D2):
                PayBillSubMenu();
                break;
            case (ConsoleKey.D3):
                RoomSignUpSubMenu();
                break;
            case (ConsoleKey.D4):
                RoomSignDownSubMenu();
                break;
            case (ConsoleKey.R):
                return;
            case (ConsoleKey.Q):
                Environment.Exit(0);
                break;
        }

    }

    private void PayBillSubMenu()
    {
        // Need to create rooms to tenants DB for this
    }

    private void RoomSignUpSubMenu()
    {
        // Need to create rooms to tenants DB for this
    }

    private void RoomSignDownSubMenu()
    {
        throw new NotImplementedException();
    }

    private void IssueConversationsSubmenu(int tenantId)
    {
        Console.Clear();
        ConversationManager conversationManager = new();
        List<Conversation>? listOfConversations = conversationManager.GetIdAssociatedConvos(tenantId);

        if (listOfConversations != null)
        {
            TenantDB tenantDB = new();
            foreach (var conversation in listOfConversations)
            {
                Tenant tenantNameGetter = tenantDB.SelectSingle(conversation.TenantId);
                Console.WriteLine($"{conversation.Id}). {conversation.Title} | {tenantNameGetter.FullName} \n");
            }
        }
        Console.Write("Please select a conversation or enter [N] to start a new one:");
        string? input = Console.ReadLine();

        int inputId;

        if (input?.ToLower() == "n") inputId = ConvoCreationSubMenu(tenantId);
        else inputId = inputController.TryIntConversion(input);

        ConversationGUI chosenConversation;
        if (!inputController.CheckIfNegative(inputId) && inputId != 0)
        {
            chosenConversation = new(inputId);
            bool success = chosenConversation.EnterConversation(false, tenantId);
            if (!success)
            {
                Console.WriteLine("Something went wrong trying to initialize messages...");
                Console.ReadKey();
                return;
            }
        }
    }

    private int ConvoCreationSubMenu(int tenantId)
    {
        Console.Clear();
        ConversationManager conversationManager = new();

        Console.Write("Please Enter the title of your new conversation: ");
        string? titleInput = Console.ReadLine();

        if (!String.IsNullOrEmpty(titleInput))
        {
            int identity = conversationManager.NewConversation(tenantId, titleInput);
            return identity;
        }
        return 0;
    }
}