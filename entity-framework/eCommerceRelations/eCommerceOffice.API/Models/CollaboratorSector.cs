namespace eCommerceOffice.API.Models;

public class CollaboratorSector
{
    public DateTimeOffset RegisterDate { get; set; }
        
    public int CollaboratorId { get; set; }
    public int SectorId { get; set; }
        
    public Collaborator Collaborator { get; set; }
    public Sector Sector { get; set; }
}