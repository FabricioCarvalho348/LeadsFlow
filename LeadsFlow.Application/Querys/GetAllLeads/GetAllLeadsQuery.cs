using LeadsFlow.Application.Models;
using MediatR;

namespace LeadsFlow.Application.Querys.GetAllLeads;

public class GetAllLeadsQuery : IRequest<ResultViewModel<List<LeadViewModel>>>
{
    
}