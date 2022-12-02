internal class Conversation
{
    //DB props
    public int id { get; }
    public int TenantId { get; set; }
    public string? Title { get; set; }
    public bool IsArchived { get; set; }

    // Runtime props
    public List<Message>? IssueMessages { get; set; }

    //TODO: Implement message getter v
    public Conversation()
    {

    }
}