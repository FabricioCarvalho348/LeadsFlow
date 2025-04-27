using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Enums;
using MediatR;

namespace LeadsFlow.Application.Commands.UpdateLead;

public class UpdateLeadCommand : IRequest<ResultViewModel>
{
    public long Id { get; set; }
    public string ContactFirstName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactPhone { get; set; }
    public string ContactEmail { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public DateTime DateCreated { get; set; }
    public LeadStatus Status { get; set; }
}