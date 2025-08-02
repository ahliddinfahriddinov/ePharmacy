namespace ePharmacy.Application.Dtos.CartDtos;
public class CartDto
{
    public long CartId { get; set; }
    public decimal TotalAmount { get; set; }
    public bool IsActive { get; set; }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
