namespace VineyardManager.Models
{
    public class Vineyard
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }

    }
}
