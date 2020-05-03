using System.ComponentModel.DataAnnotations.Schema;

namespace PartTimeV1.Data
{
    public class BrandsListsEntity : Entity
    {
        public string Company { get; set; }
        public string Brands { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}