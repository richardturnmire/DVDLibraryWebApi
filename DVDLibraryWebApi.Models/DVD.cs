using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryWebApi.Models
{
    public class DVD
    {
        public int dvdId { get; set; }
        public string title { get; set; }
        public Int16 realeaseYear { get; set; }
        public string director { get; set; }
        public string rating { get; set; }
        public string notes { get; set; }
    }
}