using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibraryWebApi.Models;
using DVDLibraryWebApi.Models.Interfaces;

namespace DVDLibraryWebApi.Data.Repositories
{
    public class ADO_Repository : IDVDRepository
    {
        private static List<DVD> _dvds = new List<DVD>();

        public DVD Get(int id)
        {
            return new DVD();
        }

        public List<DVD> All()
        {
            return _dvds;
        }

        public List<DVD> GetByTitle(string title)
        {
            return _dvds;
        }
        public List<DVD> GetByYear(Int16 year)

        {
            return _dvds;
        }
        public List<DVD> GetByDirector(string director)

        {
            return _dvds;
        }
        public List<DVD> GetByRating(string rating)
        {
            return _dvds;
        }


        public int AddDVD(DVD newDVD)
        {
            return -1;
        }
        public void UpdateDVD(int id, DVD aDVD)
        {
        }
        public void DeleteDVD(int id)
        {
        }
    }
}
