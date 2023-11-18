namespace tparf.Api.Entities
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}
