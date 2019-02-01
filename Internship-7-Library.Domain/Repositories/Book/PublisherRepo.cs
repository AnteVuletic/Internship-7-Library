﻿using System;
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

        public List<Publisher> GetAllPublisher()
        {
            return _context.Publishers.ToList();
        }

        public bool AddPublisher(string publisherName, string publisherCountry)
        {
            if (!_context.Publishers.Any(publish => publish.Name == publisherName))
            {
                _context.Publishers.Add(new Publisher(publisherName, publisherCountry));
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool RemovePublisher(int publisherId)
        {
            var publisherFound = GetPublisher(publisherId);
            if (publisherFound != null)
            {
                _context.Publishers.Remove(publisherFound);
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool EditPublisher(int publisherId, string publisherName, string publisherCountry)
        {
            return RemovePublisher(publisherId) && AddPublisher(publisherName, publisherCountry);
        }
    }
}
