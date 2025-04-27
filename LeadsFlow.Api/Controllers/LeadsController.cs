using LeadsFlow.Application.Commands.AcceptedLead;
using LeadsFlow.Application.Commands.DeclinedLead;
using LeadsFlow.Application.Commands.DeleteLead;
using LeadsFlow.Application.Commands.InsertLead;
using LeadsFlow.Application.Commands.UpdateLead;
using LeadsFlow.Application.Querys.GetAllLeads;
using LeadsFlow.Application.Querys.GetLeadById;
using LeadsFlow.Application.Querys.GetLeadByStatus;
using LeadsFlow.Domain.Enums;
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetLeadByIdQuery(id));

        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return Ok(result);
    }
    
    
    [HttpGet("status")]
    public async Task<IActionResult> GetByStatus([FromQuery] LeadStatus status)
    {
        var query = new GetLeadByStatusQuery(status);
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
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateLeadCommand command)
    {
        var result = await _mediator.Send(command);
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteLeadCommand(id));
        
        if (!result.IsSuccess)
        {
            return BadRequest(result.Message);
        }
        
        return NoContent();
    }
    
    [HttpPut("{id}/accept")]
    public async Task<IActionResult> Accept(long id)
    {
        var command = new AcceptedLeadCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok();
    }

    [HttpPut("{id}/decline")]
    public async Task<IActionResult> Decline(long id)
    {
        var command = new DeclinedLeadCommand(id);
        var result = await _mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result.Message);

        return Ok();
    }
}