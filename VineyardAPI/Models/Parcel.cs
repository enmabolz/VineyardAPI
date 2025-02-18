namespace VineyardAPI.Models
{
    public class Parcel
    {
        public int Id { get; set; } 
        public required int ManagerId { get; set; } 
        public virtual Manager Manager { get; set; } 

        public required int VineyardId { get; set; } 
        public virtual Vineyard Vineyard { get; set; } 

        public required int GrapeId { get; set; }
        public virtual Grape Grape { get; set; } 

        public int YearPlanted { get; set; } 
        public int Area { get; set; } 
    }
}

