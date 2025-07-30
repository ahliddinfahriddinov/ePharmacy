using ePharmacy.Domain.Enums;

namespace ePharmacy.Domain.Entities;
public class Drug : BaseEntity
{
    public long DrugId { get; set; }
    public string Name { get; set; }
    public string GenericName { get; set; }
    public string Manufacturer { get; set; }
    public string Description { get; set; }
    public DrugCategory Category { get; set; }
    public string Dosage { get; set; }
    public string ActiveIngredients { get; set; }
    public string SideEffects { get; set; }
    public string Contraindications { get; set; }
    public bool RequiresPrescription { get; set; }
    public string ImageUrl { get; set; }
    public string Barcode { get; set; }

    public ICollection<PharmacyDrug> PharmacyDrugs { get; set; } = new List<PharmacyDrug>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
}
