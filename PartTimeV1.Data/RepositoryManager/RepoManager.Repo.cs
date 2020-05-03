using PartTimeV1.Data.Repository;

namespace PartTimeV1.Data.RepositoryManager
{
    public partial class RepoManager
    {
        private DistrictsRepo districtsRepo = null;
        public DistrictsRepo DistrictsRepo
        {
            get
            {
                if (this.districtsRepo == null)
                {
                    this.districtsRepo = new DistrictsRepo(this.dbContext);
                }
                return this.districtsRepo;
            }
        }
    }
}