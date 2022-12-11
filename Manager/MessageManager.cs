class MessageManager
{
    ICrud<Message> messageDbCaller;

    public MessageManager()
    {
        messageDbCaller = new MessageDB();
    }

    public void SendNewMessage(int senderId, string message, int conversationId, bool sentByLandlord)
    {
        if (sentByLandlord)
        {
            Message sentMessage = new()
            {
                ConversationId = conversationId,
                LandlordId = senderId,
                TenantId = null,
                Message_ = message
            };
            messageDbCaller.Create(sentMessage);
        }
        else
        {
            Message sentMessage = new()
            {
                ConversationId = conversationId,
                TenantId = senderId,
                LandlordId = null,
                Message_ = message
            };
            messageDbCaller.Create(sentMessage);
        }
    }
}