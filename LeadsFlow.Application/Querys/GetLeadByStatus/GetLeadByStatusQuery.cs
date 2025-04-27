using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Enums;
using MediatR;

namespace LeadsFlow.Application.Querys.GetLeadByStatus;

public class GetLeadByStatusQuery : IRequest<ResultViewModel<List<LeadViewModel>>>
{
    public LeadStatus Status { get; set; }

    public GetLeadByStatusQuery(LeadStatus status)
    {
        Status = status;
    }
}