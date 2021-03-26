namespace PartTimeV1.Data.Repository
{
    public class DistrictsEntity : Entity
    {
        public int DistrictId { get; set; }
        public int ProvincetId { get; set; }
        public string DistrictName { get; set; }
    }
}