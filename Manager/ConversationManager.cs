class ConversationManager
{
    ICrud<Conversation> conversationDbCaller;
    ISelectWhere<Conversation> convoSelectWhereCaller;

    public ConversationManager()
    {
        conversationDbCaller = new ConversationDB();
        convoSelectWhereCaller = new ConversationDB();
    }

    public void ArchiveConversation(Conversation conversation)
    {
        conversation.IsArchived = true;
        conversationDbCaller.Update(conversation);
    }

    public List<Conversation> GetNonArchivedConvos()
    {
        List<Conversation> resultConversations = conversationDbCaller.Read();
        resultConversations.RemoveAll(x => x.IsArchived == true);

        return resultConversations;
    }

    public List<Conversation> GetIdAssociatedConvos(int id)
    {
        List<Conversation> resultConversations = convoSelectWhereCaller.SelectWhere(id);
        resultConversations.RemoveAll(x => x.IsArchived == true);

        return resultConversations;
    }

    internal int NewConversation(int tenantId, string title)
    {
        Conversation newConversation = new()
        {
            TenantId = tenantId,
            Title = title,
            IsArchived = false
        };

        int identity = conversationDbCaller.Create(newConversation);
        return identity;
    }
}