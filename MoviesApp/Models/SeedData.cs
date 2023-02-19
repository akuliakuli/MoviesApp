using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;

namespace MoviesApp.Models
{
	public class SeedData
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using (var context = new MoviesAppContext(
				serviceProvider.GetRequiredService<
					DbContextOptions<MoviesAppContext>>()))
			{
				if (context == null || context.Movie == null)
				{
					throw new ArgumentNullException("Null RazorPagesMovieContext");
				}

				// Look for any movies.
				if (context.Movie.Any())
				{
					return;   // DB has been seeded
				}

				context.Movie.AddRange(
					new Movie
					{
						Title = "La Haine",
						ReleaseDate = DateTime.Parse("1996-5-31"),
						Genre = "Drama/Crime",
						Price = 19.99M,
						Rating = "R"
					},

					new Movie
					{
						Title = "Fear and Loathing in Las Vegas",
						ReleaseDate = DateTime.Parse("1998-5-19"),
						Genre = "Comedy/Adventure",
						Price = 4.20M,
                        Rating = "N"
                    },

					new Movie
					{
						Title = "Ghostbusters 2",
						ReleaseDate = DateTime.Parse("1986-2-23"),
						Genre = "Comedy",
						Price = 9.99M,
                        Rating = "S"
                    },

					new Movie
					{
						Title = "Predator",
						ReleaseDate = DateTime.Parse("1959-4-15"),
						Genre = "Western",
						Price = 3.99M,
                        Rating = "PG13"

                    },
                    new Movie
                    {
                        Title = "Dumb and dumber",
                        ReleaseDate = DateTime.Parse("2003-5-25"),
                        Genre = "Historical",
                        Price = 25M,
                        Rating = "V"
                    }
                );
				context.SaveChanges();
			}
		}
	}
}
