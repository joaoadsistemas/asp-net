namespace eCommerceOffice.Models;


// Relacionamento Many-to-Many depois do EF 5.0
public class CollaboratorVehicle
{
    
    public DateTimeOffset RegisterBond { get; set; }
    
    // MER
    public int CollaboratorId { get; set; }
    public int VehicleId { get; set; }
    
    // POO
    public Collaborator Collaborator { get; set; }
    public Vehicle Vehicle { get; set; }
}