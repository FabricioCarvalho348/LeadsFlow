using LeadsFlow.Domain.Entities;
using LeadsFlow.Domain.Enums;
using LeadsFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LeadsFlow.Infrastructure.DataAccess.Repositories;

public class LeadRepository : ILeadRepository
{
    
    private readonly LeadsFlowDbContext _dbContext;
    
    public LeadRepository(LeadsFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Task<List<Lead>> GetAll()
    {
        var leads = _dbContext.Leads.ToListAsync();
        return leads;
    }

    public async Task<Lead?> GetById(long id)
    {
        return await _dbContext.Leads.SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Lead>> GetByStatusAsync(LeadStatus status)
    {
        return await _dbContext.Leads
            .Where(lead => lead.Status == status)
            .ToListAsync();
    }

    public async Task Add(Lead lead)
    {
        await _dbContext.Leads.AddAsync(lead);
        await _dbContext.SaveChangesAsync();
    }

    public Task Update(Lead lead)
    {
        _dbContext.Leads.Update(lead);
        return _dbContext.SaveChangesAsync();
    }

    public Task<bool> Exists(long id)
    {
        return _dbContext.Leads.AnyAsync(x => x.Id == id);
    }
}