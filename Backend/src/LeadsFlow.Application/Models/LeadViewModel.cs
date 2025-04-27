using LeadsFlow.Domain.Entities;
using LeadsFlow.Domain.Enums;

namespace LeadsFlow.Application.Models;

public class LeadViewModel
{
    public LeadViewModel(long id, string contactFirstName, string contactLastName, string contactPhone, string contactEmail, DateTime dateCreated, string suburb, string category, string description, decimal price, LeadStatus status)
    {
        Id = id;
        ContactFirstName = contactFirstName;
        ContactLastName = contactLastName;
        ContactPhone = contactPhone;
        ContactEmail = contactEmail;
        DateCreated = dateCreated;
        Suburb = suburb;
        Category = category;
        Description = description;
        Price = price;
        Status = status;
    }

    public long Id { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public DateTime DateCreated { get; set; }
    public string Suburb { get; set; }
    public string Category { get;  set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public LeadStatus Status { get; set; }

    public static LeadViewModel FromEntity(Lead lead)
    => new(lead.Id, 
        lead.ContactFirstName, 
        lead.ContactLastName, 
        lead.ContactPhone, 
        lead.ContactEmail, 
        lead.DateCreated, 
        lead.Suburb, 
        lead.Category, 
        lead.Description, 
        lead.Price, 
        lead.Status);
}
