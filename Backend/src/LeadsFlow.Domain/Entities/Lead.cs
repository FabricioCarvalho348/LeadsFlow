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
    
    public void Update(string contactFirstName, string contactLastName, string contactPhone, string contactEmail,
        string suburb, string category, string description, decimal price, DateTime requestDateCreated,
        LeadStatus status)
    {
        ContactFirstName = contactFirstName;
        ContactLastName = contactLastName;
        ContactPhone = contactPhone;
        ContactEmail = contactEmail;
        Suburb = suburb;
        Category = category;
        Description = description;
        Price = price;
        Status = status;
    }
    
    public void Accept()
    {
        if (Price >= 500)
        {
            var discount = Price * 0.10m;
            Price -= discount;
        }

        Status = LeadStatus.Accepted;
    }

    public void Decline()
    {
        Status = LeadStatus.Declined;
    }
}