namespace eCommerceOffice.Models;

// Relacionamento Many-to-Many antes do EF 5.0
public class CollaboratorSector
{
    public DateTimeOffset RegisterDate { get; set; }
        
    public int CollaboratorId { get; set; }
    public int SectorId { get; set; }
        
    public Collaborator Collaborator { get; set; }
    public Sector Sector { get; set; }
}