namespace ePharmacy.Domain.Entities;
public class OrderItem : BaseEntity
{
    public long OrderItemId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Instructions { get; set; }

    public long OrderId { get; set; }
    public Order Order { get; set; }

    public long DrugId { get; set; }
    public Drug Drug { get; set; }
}
