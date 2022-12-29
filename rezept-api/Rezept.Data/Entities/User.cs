namespace Rezept.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; }

    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}
