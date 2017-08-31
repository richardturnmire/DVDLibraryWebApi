
using System;
using System.Collections.Generic;
using DVDLibraryWebApi.Models;
using DVDLibraryWebApi.Models.Interfaces;
using System.Linq;

namespace DVDLibraryWebApi.Data.Repositories
{
    public class Mock_Repository : IDVDRepository
    {
        private static List<DVD> _dvds = new List<DVD>();

        public Mock_Repository()
        {
            _dvds.Add(new DVD
                {
                    dvdId = 1,
                    title = "Mock DVD 1",
                    director = "Mock Director 1",
                    rating = "G",
                    realeaseYear = 2017,
                    notes = "Dummy data"
                }
            );

            _dvds.Add(
                new DVD
                {
                    dvdId = 2,
                    title = "Mock DVD 2",
                    director = "Mock Director 2",
                    rating = "G",
                    realeaseYear = 2017,
                    notes = "Dummy data"
                }
           );

            _dvds.Add(
                new DVD
                {
                    dvdId = 3,
                    title = "Mock DVD 3",
                    director = "Mock Director 3",
                    rating = "G",
                    realeaseYear = 2017,
                    notes = "Dummy data"
                }
            );

            _dvds.Add(
                new DVD
                {
                    dvdId = 4,
                    title = "Mock DVD 4",
                    director = "Mock Director 4",
                    rating = "G",
                    realeaseYear = 2017,
                    notes = "Dummy data"
                }
            );

            _dvds.Add(
                new DVD
                {
                    dvdId = 5,
                    title = "Mock DVD 5",
                    director = "Mock Director 5",
                    rating = "G",
                    realeaseYear = 2017,
                    notes = "Dummy data"
                }
            );
        }

        public DVD Get(int id)
        {
            if (id >= 1 && id <= _dvds.Count)
                return _dvds.Where(d => d.dvdId == id).FirstOrDefault();
            else
                return null;
        }

        public List<DVD> All()
        {
            return _dvds.OrderBy(d=>d.dvdId).ToList();
        }

        public List<DVD> GetByTitle(string title)
        {
            return _dvds.FindAll(d=> d.title.Contains(title));
        }

        public List<DVD> GetByYear(Int16 year)
        {
            return _dvds.FindAll(d => d.realeaseYear == year);
        }

        public List<DVD> GetByDirector(string director)
        {
            return _dvds.FindAll(d => d.director.Contains(director));
        }

        public List<DVD> GetByRating(string rating)
        {
            return _dvds.FindAll(d => d.rating == rating);
        }

        public int AddDVD(DVD newDVD)
        {
            newDVD.dvdId = _dvds.Max(d => d.dvdId) + 1; ;
            _dvds.Add(newDVD);
             
            return _dvds.Count();
        }

        public void UpdateDVD(int id, DVD aDVD)
        {
            _dvds.RemoveAll(d => d.dvdId == id);
            _dvds.Add(aDVD);
             
        }

        public void DeleteDVD(int id)
        {
            _dvds.RemoveAll(d => d.dvdId == id);
        }
    }
}

