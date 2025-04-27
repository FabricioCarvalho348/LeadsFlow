using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Commands.InsertLead;

public class InsertLeadHandler : IRequestHandler<InsertLeadCommand, ResultViewModel<long>>
{
    private readonly ILeadRepository _repository;

    public InsertLeadHandler(ILeadRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel<long>> Handle(InsertLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = request.ToEntity();

        await _repository.Add(lead);

        return ResultViewModel<long>.Success(lead.Id);
    }
}