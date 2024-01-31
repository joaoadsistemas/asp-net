namespace eCommerceOffice.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Plate { get; set; }
        
        
        
    public List<Collaborator> Collaborators  { get; set; } = new List<Collaborator>();
    
    // Relacionamento Many-to-Many depois do EF 5.0
    public List<CollaboratorVehicle> CollaboratorVehicles { get; set; } = new List<CollaboratorVehicle>();

}