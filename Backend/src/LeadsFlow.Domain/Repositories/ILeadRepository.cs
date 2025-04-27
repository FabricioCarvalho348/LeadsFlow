using LeadsFlow.Domain.Entities;
using LeadsFlow.Domain.Enums;

namespace LeadsFlow.Domain.Repositories;

public interface ILeadRepository
{
    Task<List<Lead>> GetAll();
    Task<Lead?> GetById(long id);
    Task<List<Lead>> GetByStatusAsync(LeadStatus status);
    Task Add(Lead lead);
    Task Update(Lead lead);
    Task<bool> Exists(long id);
}