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
    }
}