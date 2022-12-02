internal class Message
{
    public int Id { get; }
    public int ConversationId { get; set; }
    public int? TenantId { get; set; }
    public int? LandlordId { get; set; }
    public string Message_ { get; set; }
}