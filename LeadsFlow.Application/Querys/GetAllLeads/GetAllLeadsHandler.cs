using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Querys.GetAllLeads;

public class GetAllLeadsHandler : IRequestHandler<GetAllLeadsQuery, ResultViewModel<List<LeadViewModel>>>
{
    private readonly ILeadRepository _leadRepository;
    
    public GetAllLeadsHandler(ILeadRepository leadRepository)
    {
        _leadRepository = leadRepository;
    }


    public async Task<ResultViewModel<List<LeadViewModel>>> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
    {
        var projects = await _leadRepository.GetAll();
        
        var model = projects.Select(LeadViewModel.FromEntity).ToList();
        
        return ResultViewModel<List<LeadViewModel>>.Success(model);
    }
}