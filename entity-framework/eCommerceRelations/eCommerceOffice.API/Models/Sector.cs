namespace eCommerceOffice.API.Models;

public class Sector
{
    public int Id { get; set; }
    public string Name { get; set; }
        
        
    // Relacionamento Many-to-Many antes do EF 5.0
    public List<CollaboratorSector> CollaboratorSector  { get; set; } = new List<CollaboratorSector>();
}