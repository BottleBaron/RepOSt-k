class ConversationGUI
{
    private Conversation activeConversation;
    private MessageManager messageManager = new();
    private ConversationManager convoManager = new();
    private bool isReturning = false;

    public ConversationGUI(int conversationId)
    {
        ISelectSingle<Conversation> conversationCaller = new ConversationDB();
        Conversation result = conversationCaller.SelectSingle(conversationId);

        activeConversation = result;
        activeConversation.GetAssociatedMessages();
    }

    public bool EnterConversation(bool isLandLord, int currentUserId)
    {

        if (activeConversation == null || activeConversation.IssueMessages == null) return false;

        while (true)
        {
            Console.Clear();

            foreach (var message in activeConversation.IssueMessages)
            {
                Console.WriteLine(message.T3 + ": " + message.T2 + "\n");
            }


            if (isLandLord) AdminInteractions(currentUserId);
            else UserInteractions(currentUserId);

            if (isReturning) break;
        }
        return true;
    }

    public void UserInteractions(int currentUserId)
    {
        Console.WriteLine("[A]: Answer [U]: Update [R]: Return");
        var keyPress = Console.ReadKey(true);

        if (keyPress.Key == ConsoleKey.A)
        {
            Console.Write("\nPlease enter your message:");
            string? inputMessage = Console.ReadLine();

            if (!String.IsNullOrEmpty(inputMessage))
            {
                messageManager.SendNewMessage(currentUserId, inputMessage, activeConversation.Id, false);
                activeConversation.GetAssociatedMessages();
            }
        }
        else if (keyPress.Key == ConsoleKey.U)
        {
            activeConversation.GetAssociatedMessages();
        }
        else if (keyPress.Key == ConsoleKey.R) isReturning = true;
    }

    public void AdminInteractions(int currentUserId)
    {
        Console.WriteLine("[A]: Answer [U]: Update [R]: Return [X]: Archive Conversation");
        var keyPress = Console.ReadKey(true);

        if (keyPress.Key == ConsoleKey.A)
        {
            Console.Write("\nPlease enter your message:");
            string? inputMessage = Console.ReadLine();

            if (!String.IsNullOrEmpty(inputMessage))
            {
                messageManager.SendNewMessage(currentUserId, inputMessage, activeConversation.Id, true);
                activeConversation.GetAssociatedMessages();
            }
        }
        else if (keyPress.Key == ConsoleKey.U) activeConversation.GetAssociatedMessages();
        else if (keyPress.Key == ConsoleKey.R) isReturning = true;
        else if (keyPress.Key == ConsoleKey.X)
        {
            convoManager.ArchiveConversation(activeConversation);
            isReturning = true;
        }
    }


}