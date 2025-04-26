using LeadsFlow.Domain.Entities;

namespace LeadsFlow.Domain.Repositories;

public interface ILeadRepository
{
    Task<List<Lead>> GetAll();
    Task<Lead?> GetById(long id);
    Task Add(Lead lead);
    Task Update(Lead lead);
    Task<bool> Exists(long id);
}