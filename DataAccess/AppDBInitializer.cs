﻿using AppDisney.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppDisney.DataAccess
{
    public class AppDBInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDBContext>();

                context.Database.EnsureCreated();

                if (!context.Characters.Any())
                {
                    context.Characters.AddRange(new List<Character>()
                    {
                        new Character()
                        {
                            Name = "Character 1",
                            Age = 23,
                            Weight = 45,
                            History = "History of character 1",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },

                        new Character()
                        {
                            Name = "Character 2",
                            Age = 36,
                            Weight = 80,
                            History = "History of character 2",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },

                        new Character()
                        {
                            Name = "Character 3",
                            Age = 10,
                            Weight = 47,
                            History = "History of character 3",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },

                        new Character()
                        {
                            Name = "Character 4",
                            Age = 24,
                            Weight = 75,
                            History = "History of character 4",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },

                        new Character()
                        {
                            Name = "Character 5",
                            Age = 67,
                            Weight = 96,
                            History = "History of character 5",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },

                        new Character()
                        {
                            Name = "Character 6",
                            Age = 23,
                            Weight = 45,
                            History = "History of character 6",
                            Image = "https://prod.liveshare.vsengsaas.visualstudio.com/join?12955AB6BEE18FDA0DD7362F89BBE78557AB",
                        },
                    });
                    context.SaveChanges();
                }

                if (!context.MoviesOrSeries.Any())
                {
                    context.MoviesOrSeries.AddRange(new List<MovieOrSerie>()
                    {

                        new MovieOrSerie()
                        {
                            Name = "Movie 1",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 3,
                            GenreId = 2,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 2",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 4,
                            GenreId = 1,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 3",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 5,
                            GenreId = 3,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 4",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 2,
                            GenreId = 3,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 5",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 1,
                            GenreId = 1,
                        },

                        new MovieOrSerie()
                        {
                            Name = "Movie 6",
                            Image = "Image",
                            CreatedAt = DateTime.Now,
                            Calification = 3,
                            GenreId = 1,
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Genres.Any())
                {

                    context.Genres.AddRange(new List<Genre>()
                    {

                        new Genre()
                        {
                            Name = "Accion"
                        },

                        new Genre()
                        {
                            Name = "Suspenso"
                        },

                        new Genre()
                        {
                            Name = "Drama"
                        },

                        new Genre()
                        {
                            Name = "Comedia"
                        },

                        new Genre()
                        {
                            Name = "Aventura"
                        },
                    });
                    context.SaveChanges();
                }


                if (!context.CharacterMovies.Any())
                {
                    context.CharacterMovies.AddRange(new List<CharacterMovie>()
                    {

                        new CharacterMovie()
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 2,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 1,
                            MovieOrSerieId = 4,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 2,
                            MovieOrSerieId = 1,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 5,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 3,
                            MovieOrSerieId = 3,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 4,
                            MovieOrSerieId = 5,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 4,
                            MovieOrSerieId = 1,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 5,
                            MovieOrSerieId = 6,
                        },

                        new CharacterMovie()
                        {
                            CharacterId = 6,
                            MovieOrSerieId = 1,
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}





                        