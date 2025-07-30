namespace ePharmacy.Domain.Entities;
public class PharmacyDrug : BaseEntity
{
    public long PharmacyDrugId { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public bool IsAvailable { get; set; } = true;

    public long PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; }

    public long DrugId { get; set; }
    public Drug Drug { get; set; }
}