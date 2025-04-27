using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Commands.UpdateLead;

public class UpdateLeadHandler: IRequestHandler<UpdateLeadCommand, ResultViewModel>
{
    private readonly ILeadRepository _repository;
    
    public UpdateLeadHandler(ILeadRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel> Handle(UpdateLeadCommand request, CancellationToken cancellationToken)
    {
        var project = await _repository.GetById(request.Id);
        
        if (project is null)
        {
            return ResultViewModel.Error("Lead not found");
        }
        
        project.Update(
            request.ContactFirstName,
            request.ContactLastName,
            request.ContactPhone,
            request.ContactEmail,
            request.Suburb,
            request.Category,
            request.Description,
            request.Price,
            request.DateCreated,
            request.Status);
        
        await _repository.Update(project);
        
        return ResultViewModel.Success();
    }
}