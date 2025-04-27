using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Entities;
using LeadsFlow.Domain.Enums;
using MediatR;

namespace LeadsFlow.Application.Commands.InsertLead;

public class InsertLeadCommand : IRequest<ResultViewModel<long>>
{
    public string ContactFirstName { get; set; } = string.Empty;
    public string ContactLastName { get; set; } = string.Empty;
    public string ContactPhone { get; set; } = string.Empty;
    public string ContactEmail { get; set; } = string.Empty;
    public string Suburb { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    
    public Lead ToEntity()
        => new()
        {
            ContactFirstName = ContactFirstName,
            ContactLastName = ContactLastName,
            ContactPhone = ContactPhone,
            ContactEmail = ContactEmail,
            Suburb = Suburb,
            Category = Category,
            Description = Description,
            Price = Price,
            DateCreated = DateTime.UtcNow,
            Status = LeadStatus.New
        };
}