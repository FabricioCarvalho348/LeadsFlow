using LeadsFlow.Application.Models;
using MediatR;

namespace LeadsFlow.Application.Commands.DeleteLead;

public class DeleteLeadCommand: IRequest<ResultViewModel>
{
    public long Id { get; set; }
    
    public DeleteLeadCommand(long id)
    {
        Id = id;
    }
}