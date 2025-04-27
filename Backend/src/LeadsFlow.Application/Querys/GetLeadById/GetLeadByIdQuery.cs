using LeadsFlow.Application.Models;
using MediatR;

namespace LeadsFlow.Application.Querys.GetLeadById;

public class GetLeadByIdQuery: IRequest<ResultViewModel<LeadViewModel>>
{
    public GetLeadByIdQuery(long id)
    {
        Id = id;
    }

    public long Id { get; set; }
}