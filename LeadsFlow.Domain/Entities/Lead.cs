using LeadsFlow.Domain.Enums;

namespace LeadsFlow.Domain.Entities;

public class Lead : BaseEntity
{
    public string ContactFirstName { get; set; } = string.Empty;
    public string ContactLastName { get; set; } = string.Empty;
    public string ContactPhone { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string Suburb { get; set; } = string.Empty;
    public string Category { get;  set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public LeadStatus Status { get; set; } = LeadStatus.New;
}