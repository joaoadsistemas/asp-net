namespace eCommerceOffice.API.Models;

public class Collaborator
{
    public int Id { get; set; }
    public string Name { get; set; }


    public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    // Relacionamento Many-to-Many antes do EF 5.0
    public List<CollaboratorSector> CollaboratorSectors { get; set; } = new List<CollaboratorSector>();
    public List<Class> Classes { get; set; } = new List<Class>();
}