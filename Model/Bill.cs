internal class Bill
{
    public int Id { get; }
    public int TenantId { get; set; }
    public int RoomId { get; set; }
    public int LandlordId { get; set; }
    public DateOnly BillDate { get; set; }
    public DateOnly PaymentDueDate { get; set; }
    public string? OcrNumber { get; set; }
    public int Price { get; set; }
    public DateTime? PaidDate { get; set; }
}