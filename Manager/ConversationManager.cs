class ConversationManager
{
    ICrud<Conversation> conversationDbCaller;

    public ConversationManager()
    {
        conversationDbCaller = new ConversationDB();
    }

    public void ArchiveConversation(Conversation conversation)
    {
        conversation.IsArchived = true;
        conversationDbCaller.Update(conversation);
    }
}