using LeadsFlow.Application.Models;
using MediatR;

namespace LeadsFlow.Application.Commands.AcceptedLead;

public class AcceptedLeadCommand: IRequest<ResultViewModel>
{
    public long Id { get; }

    public AcceptedLeadCommand(long id)
    {
        Id = id;
    }
}