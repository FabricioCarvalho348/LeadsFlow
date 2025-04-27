using LeadsFlow.Application.Models;
using LeadsFlow.Infrastructure.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LeadsFlow.Application.Commands.DeleteLead;

public class DeleteLeadHandler: IRequestHandler<DeleteLeadCommand, ResultViewModel>
{
    private readonly LeadsFlowDbContext _dbContext;
    
    public DeleteLeadHandler(LeadsFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<ResultViewModel> Handle(DeleteLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _dbContext.Leads.SingleOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);
        
        if (lead is null)
        {
            return ResultViewModel.Error("Project not found");
        }
        
        lead.SetAsDeleted();
        _dbContext.Leads.Update(lead);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return ResultViewModel.Success();
    }
}