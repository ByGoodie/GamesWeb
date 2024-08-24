namespace GamesWeb.Models.DbModel
{
    public class GameModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? LogoName { get; set; }
        public Guid AuthorId { get; set; }
        public string? MembershipIds { get; set; }
    }
}
