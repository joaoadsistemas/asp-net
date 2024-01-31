namespace eCommerceOffice.API.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Plate { get; set; }
        
        
        
    public List<Collaborator> Collaborators  { get; set; } = new List<Collaborator>();
}