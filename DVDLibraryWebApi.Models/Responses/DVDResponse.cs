using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryWebApi.Models.Responses
{
    public class DVDResponse : Response
    {
        public DVD DVD { get; set; }
    }
}