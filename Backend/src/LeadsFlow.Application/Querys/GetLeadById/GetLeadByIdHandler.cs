using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Querys.GetLeadById;

public class GetLeadByIdHandler : IRequestHandler<GetLeadByIdQuery, ResultViewModel<LeadViewModel>>
    {
    private readonly ILeadRepository _repository;
    
    public GetLeadByIdHandler(ILeadRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<ResultViewModel<LeadViewModel>> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
    {
        var lead = await _repository.GetById(request.Id);

        if (lead is null)
        {
            return ResultViewModel<LeadViewModel>.Error("Lead not found");
        }
        
        var model = LeadViewModel.FromEntity(lead);
        
        return ResultViewModel<LeadViewModel>.Success(model);
    }
}
