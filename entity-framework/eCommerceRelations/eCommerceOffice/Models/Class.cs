namespace eCommerceOffice.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
        
        
        
    public List<Collaborator> Collaborators  { get; set; } = new List<Collaborator>();
}