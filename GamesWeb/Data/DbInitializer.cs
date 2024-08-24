using GamesWeb.Models.DbModel;

namespace GamesWeb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Authors.Any())
            {
                context.Authors.AddRange(
                    new AuthorModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "Goodie"
                    }
                );
            }

            if (!context.Games.Any())
            {
                context.Games.AddRange(
                    new GameModel
                    {
                       Id = Guid.NewGuid(),
                       Name = "FarmSim",
                       Description = "A primitive farming simulator which u make ur business from very small to very big(Elon Musk style).",
                       LogoName = "FarmSim.png"
                    }
                );
            }
        }
    }
}
