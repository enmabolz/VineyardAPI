using VineyardAPI.Models;

namespace VineyardAPI.Data
{
    public class DataBaseSeeder
    {
        private readonly VineyardContext _context;

        public DataBaseSeeder(VineyardContext context) 
        {
            _context = context;
        }

        public void Seed()
        {
           
            if (!_context.Managers.Any())
            {
                SeedManagers();
            }

            if (!_context.Grapes.Any())
            {
                SeedGrapes();
            }

            if (!_context.Vineyards.Any())
            {
                SeedVineyards();
            }

            _context.SaveChanges();

            if (!_context.Parcels.Any())
            {
                SeedParcels();
            }

            _context.SaveChanges();
        }

        private void SeedManagers()
        {
            _context.Managers.AddRange(
                new Manager { TaxNumber = "132254524", Name = "Miguel Torres" },
                new Manager { TaxNumber = "143618668", Name = "Ana Martín" },
                new Manager { TaxNumber = "78903228", Name = "Carlos Ruiz" }
            );
        }

        private void SeedGrapes()
        {
            _context.Grapes.AddRange(
                new Grape { Name = "Tempranillo" },
                new Grape { Name = "Albariño" },
                new Grape { Name = "Garnacha" }
            );
        }

        private void SeedVineyards()
        {
            _context.Vineyards.AddRange(
                new Vineyard { Name = "Viña Esmeralda" },
                new Vineyard { Name = "Bodegas Bilbaínas" }
            );
        }

        private void SeedParcels()
        {
            _context.Parcels.AddRange(
                new Parcel { ManagerId = 1, VineyardId = 1, GrapeId = 1, YearPlanted = 2019, Area = 1500 },
                new Parcel { ManagerId = 2, VineyardId = 2, GrapeId = 2, YearPlanted = 2021, Area = 9000 },
                new Parcel { ManagerId = 3, VineyardId = 1, GrapeId = 1, YearPlanted = 2020, Area = 3000 },
                new Parcel { ManagerId = 1, VineyardId = 2, GrapeId = 2, YearPlanted = 2020, Area = 2000 },
                new Parcel { ManagerId = 3, VineyardId = 2, GrapeId = 2, YearPlanted = 2021, Area = 1000 }
            );
        }
    }
}
