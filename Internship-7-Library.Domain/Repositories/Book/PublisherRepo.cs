using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Internship_7_Library.Data.Entities;
using Internship_7_Library.Data.Entities.Models;

namespace Internship_7_Library.Domain.Repositories.Book
{
    public class PublisherRepo
    {
        private readonly Context _context;
        public PublisherRepo()
        {
            _context = new Context();
        }

        public Publisher GetPublisher(int publisherId)
        {
            return _context.Publishers.Find(publisherId);
        }

        public Publisher GetPublisherByName(string pubName)
        {
            return _context.Publishers.First(pub => pub.Name == pubName);
        }
        public List<Publisher> GetAllPublisher()
        {
            return _context.Publishers.ToList();
        }

        public bool AddPublisher(string publisherName, string publisherCountry)
        {
            if (_context.Publishers.Any(publish => publish.Name == publisherName)) return false;
            _context.Publishers.Add(new Publisher(publisherName, publisherCountry));
            _context.SaveChanges();
            return true;
        }

        public bool RemovePublisher(int publisherId)
        {
            var publisherFound = GetPublisher(publisherId);
            if (publisherFound == null) return false;
            if (_context.TypeBooks.Any(typbk => typbk.Publisher.PublisherId == publisherFound.PublisherId)) return false;
            _context.Publishers.Remove(publisherFound);
            _context.SaveChanges();
            return true;
        }

        public bool EditPublisher(int publisherId, string publisherName, string publisherCountry)
        {
            var publisherFound = GetPublisher(publisherId);
            if (_context.Publishers.Any(publish => publish.Name == publisherName)) return false;
            if (publisherFound == null) return false;
            publisherFound.Name = publisherName;
            publisherFound.Country = publisherCountry;
            _context.SaveChanges();
            return true;
        }
    }
}
