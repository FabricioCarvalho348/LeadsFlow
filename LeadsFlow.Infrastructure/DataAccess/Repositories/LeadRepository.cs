using LeadsFlow.Domain.Entities;
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

    public Task<Lead?> GetById(long id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Lead lead)
    {
        await _dbContext.Leads.AddAsync(lead);
        await _dbContext.SaveChangesAsync();
    }

    public Task Update(Lead lead)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Exists(long id)
    {
        throw new NotImplementedException();
    }
}