namespace GamesWeb.Models.DbModel
{
    public class MembershipModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LogoName { get; set; }
        public float Monthly { get; set; }
    }
}
