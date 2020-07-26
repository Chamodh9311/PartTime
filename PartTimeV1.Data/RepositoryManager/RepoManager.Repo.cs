using PartTimeV1.Data.Repository;

namespace PartTimeV1.Data.RepositoryManager
{
    public partial class RepoManager
    {
        private DropDownListsRepo dropDownListsRepo = null;
        public DropDownListsRepo DropDownListsRepo
        {
            get
            {
                if (this.dropDownListsRepo == null)
                {
                    this.dropDownListsRepo = new DropDownListsRepo(this.dbContext);
                }
                return this.dropDownListsRepo;
            }
        }

        private PromoterProfileRepository promoterProfileRepository = null;
        public PromoterProfileRepository PromoterProfileRepository
        {
            get
            {
                if (this.promoterProfileRepository == null)
                {
                    this.promoterProfileRepository = new PromoterProfileRepository(this.dbContext);
                }
                return this.promoterProfileRepository;
            }
        }

        private CoordinatorProfileRepository coordinatorProfileRepository = null;
        public CoordinatorProfileRepository CoordinatorProfileRepository
        {
            get
            {
                if (this.coordinatorProfileRepository == null)
                {
                    this.coordinatorProfileRepository = new CoordinatorProfileRepository(this.dbContext);
                }
                return this.coordinatorProfileRepository;
            }
        }

        private SchedulerRepository schedulerRepository = null;
        public SchedulerRepository SchedulerRepository
        {
            get
            {
                if (this.schedulerRepository == null)
                {
                    this.schedulerRepository = new SchedulerRepository(this.dbContext);
                }
                return this.schedulerRepository;
            }
        }
    }
}