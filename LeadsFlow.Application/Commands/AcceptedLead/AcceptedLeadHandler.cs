using LeadsFlow.Application.Models;
using LeadsFlow.Domain.Repositories;
using MediatR;

namespace LeadsFlow.Application.Commands.AcceptedLead;

public class AcceptedLeadHandler: IRequestHandler<AcceptedLeadCommand, ResultViewModel>
{
    private readonly ILeadRepository _repository;

    public AcceptedLeadHandler(ILeadRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResultViewModel> Handle(AcceptedLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = await _repository.GetById(request.Id);

        if (lead is null)
        {
            return ResultViewModel.Error("Project not found");
        }

        lead.Accept();

        await _repository.Update(lead);

        return ResultViewModel.Success();
    }
}