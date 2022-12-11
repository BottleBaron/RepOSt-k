internal class Conversation
{
    //DB props
    public int Id { get; }
    public int TenantId { get; set; }
    public string? Title { get; set; }
    public bool IsArchived { get; set; }

    // Runtime props
    public List<Message>? IssueMessages { get; set; }

    public Conversation()
    {
        if (Id !< 1)
        {
            ISelectWhere<Message> messageCaller = new MessageDB();
            IssueMessages = messageCaller.SelectWhere(this.Id);
        }
    }
}