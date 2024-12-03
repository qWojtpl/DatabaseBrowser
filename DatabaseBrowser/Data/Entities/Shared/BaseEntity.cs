using System.ComponentModel.DataAnnotations;

namespace DatabaseManager.Data.Entities.Shared;

public abstract class BaseEntity
{
    
    [Key]
    public int Id { get; set; }
    
}