namespace VineyardAPI.Models.Entities;

public class Grape
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<Parcel> Parcels { get; set; }
}
