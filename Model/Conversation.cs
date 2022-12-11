internal class Conversation
{
    //DB props
    public int Id { get; }
    public int TenantId { get; set; }
    public string? Title { get; set; }
    public bool IsArchived { get; set; }

    // Runtime props
    public List<SelectMapper>? IssueMessages { get; set; }

    public void GetAssociatedMessages()
    {
        if (Id > 0)
        {
            MiscellaneousDB miscDb = new();
            IssueMessages = miscDb.GetMessagesWithNames(Id);
        }
    }
}