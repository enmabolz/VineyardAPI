namespace VineyardManager.Models
{
    public class Manager
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string TaxNumber {  get; set; }

        public virtual ICollection<Parcel> Parcels { get; set; }
    }
}
