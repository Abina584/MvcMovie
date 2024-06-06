using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Evil Dead Rise",
                    ReleaseDate = DateTime.Parse("2023-4-21"),
                    Genre = "Horror",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "After Everything",
                    ReleaseDate = DateTime.Parse("2023-9-13"),
                    Genre = "Romance",
                    Rating = "R",
                    Price = 6.78M
                },
                new Movie
                {
                    Title = "Oppenheimer",
                    ReleaseDate = DateTime.Parse("2023-8-28"),
                    Genre = "Comedy",
                    Rating = "R",
                    Price = 9.12M
                },
                new Movie
                {
                    Title = "Avatar: The Way to Water",
                    ReleaseDate = DateTime.Parse("2022-11-2"),
                    Genre = "Action",
                    Rating = "R",
                    Price = 7.87M
                },
                new Movie
                {
                    Title = "Barbie",
                    ReleaseDate = DateTime.Parse("2023-7-21"),
                    Genre = "Fantasy",
                    Rating = "R",
                    Price = 7.67M
                }
            );
            context.SaveChanges();
        }
    }
}