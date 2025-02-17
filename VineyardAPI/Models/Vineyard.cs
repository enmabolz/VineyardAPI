namespace VineyardManager.Models
{
    public class Vineyard
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }

    }
}
