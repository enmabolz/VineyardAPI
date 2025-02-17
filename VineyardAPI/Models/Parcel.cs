namespace VineyardManager.Models
{
    public class Parcel
    {
        public Guid Id { get; set; }
        public required string ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
        public int VineyardId { get; set; }
        public virtual Vineyard Vineyard { get; set; }
        public int GrapeId { get; set; }
        public virtual Grape Grape { get; set; }
        public int YearPlanted { get; set; }
        public int Area { get; set; }
    }
}
