using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Querys.GetLeadByStatus;

public class GetLeadByStatusHandler : IRequestHandler<GetLeadByStatusQuery, ResultViewModel<List<LeadViewModel>>>
{
    private readonly ILeadRepository _leadRepository;

    public GetLeadByStatusHandler(ILeadRepository repository)
    {
        _leadRepository = repository;
    }

    public async Task<ResultViewModel<List<LeadViewModel>>> Handle(GetLeadByStatusQuery request,
        CancellationToken cancellationToken)
    {
        var leads = await _leadRepository.GetByStatusAsync(request.Status);
        
        var model = leads.Select(LeadViewModel.FromEntity).ToList();

        return ResultViewModel<List<LeadViewModel>>.Success(model);
    }
}