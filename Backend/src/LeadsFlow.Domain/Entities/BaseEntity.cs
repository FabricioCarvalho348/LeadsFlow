namespace LeadsFlow.Domain.Entities;

public class BaseEntity
{
    protected BaseEntity()
    { 
        IsDeleted = false;
    }
    
    public long Id { get; set; }
    public bool IsDeleted { get; private set; }
    
    public void SetAsDeleted() => IsDeleted = true;

}