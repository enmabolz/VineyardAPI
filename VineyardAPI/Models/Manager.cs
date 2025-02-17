namespace VineyardManager.Models
{
    public class Manager
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string TaxNumber {  get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }
    }
}
