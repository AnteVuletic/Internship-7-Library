using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class GenreRepo
    {
        private readonly Context _context;
        public GenreRepo()
        {
            _context = new Context();
        }

        public Genre GetGenre(int genreId)
        {
            return _context.Genres.Find(genreId);
        }
        public Genre GetGenreByText(string genreName)
        {
            return _context.Genres.First(gnr => gnr.Name == genreName);
        }
        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public bool AddGenre(string genreName, string genreDescription)
        {
            if (_context.Genres.Any(gnr => gnr.Name == genreName)) return false;
            _context.Genres.Add(genreDescription == ""
                ? new Genre(genreName)
                : new Genre(genreName, genreDescription));
            _context.SaveChanges();
            return true;
        }

        public bool RemoveGenre(int genreId)
        {
            var foundGenre = GetGenre(genreId);
            if (foundGenre == null) return false;
            _context.Genres.Remove(foundGenre);
            _context.SaveChanges();
            return true;
        }

        public bool EditGenre(int genreId,string genreName,string description)
        {
            var genreFound = GetGenre(genreId);
            if (genreFound == null) return false;
            genreFound.Name = genreName;
            genreFound.Description = description;
            return true;
        }

    }
}
