using ePharmacy.Domain.Enums;

namespace ePharmacy.Application.Dtos.DrugDtos;
public class DrugDto
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
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
