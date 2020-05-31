namespace PartTimeV1.Data.Repository
{
    public class CoordinatorProfileRepository : EFRepository<CoordinatorEntity>
    {
        public CoordinatorProfileRepository(EFDbContext dbContext)
          : base(dbContext)
        {
        }
    }
}
