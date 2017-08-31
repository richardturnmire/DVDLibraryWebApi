using System;
using System.Collections.Generic;

namespace DVDLibraryWebApi.Models.Interfaces
{
    public interface IDVDRepository 
    {
        DVD Get(int id);
        List<DVD> All();
        List<DVD> GetByTitle(string title);
        List<DVD> GetByYear(Int16 year);
        List<DVD> GetByDirector(string director);
        List<DVD> GetByRating(string rating);
        int AddDVD(DVD newDVD);
        void UpdateDVD(int id, DVD aDVD);
        void DeleteDVD(int id);







    }
}