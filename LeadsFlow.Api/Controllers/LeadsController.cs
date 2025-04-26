using LeadsFlow.Application.Commands.InsertLead;
using LeadsFlow.Application.Querys.GetAllLeads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadsFlow.Api.Controllers;


public class LeadsController : LeadsFlowBaseController
{
    private readonly IMediator _mediator;

    public LeadsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllLeadsQuery();
        
        var result = await _mediator.Send(query);

        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(InsertLeadCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok();
    }
}