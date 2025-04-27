using LeadsFlow.Application.Models;
using MediatR;

namespace LeadsFlow.Application.Commands.DeclinedLead;

public class DeclinedLeadCommand: IRequest<ResultViewModel>
{
    public long Id { get; }

    public DeclinedLeadCommand(long id)
    {
        Id = id;
    }
}
