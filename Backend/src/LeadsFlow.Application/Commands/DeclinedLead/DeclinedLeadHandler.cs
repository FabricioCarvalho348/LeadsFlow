using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Commands.DeclinedLead;

public class DeclinedLeadHandler : IRequestHandler<DeclinedLeadCommand, ResultViewModel>
{
private readonly ILeadRepository _repository;

public DeclinedLeadHandler(ILeadRepository repository)
{
    _repository = repository;
}

public async Task<ResultViewModel> Handle(DeclinedLeadCommand request, CancellationToken cancellationToken)
{
    var lead = await _repository.GetById(request.Id);

    if (lead is null)
    {
        return ResultViewModel.Error("Lead not found");
    }

    lead.Decline();

    await _repository.Update(lead);

    return ResultViewModel.Success();
}
}