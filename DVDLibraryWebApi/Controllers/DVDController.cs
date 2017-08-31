using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using DVDLibraryWebApi.Models;
using DVDLibraryWebApi.Models.Interfaces;

namespace DVDLibraryWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")] 
    [RoutePrefix("")]
    public class DVDController : ApiController
    {
        private static IDVDRepository _dvdRepository;

        public DVDController(IDVDRepository dvdRepository)
        {
            _dvdRepository = dvdRepository;
        }

        [Route("dvds")]
       [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(_dvdRepository.All());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id)
        {
            DVD dvd = _dvdRepository.Get(id);

            if ( dvd == null )
            {
                return NotFound();
            }
            else
            { 
                return Ok(dvd);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            List<DVD> dvd = _dvdRepository.GetByTitle(title);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/realease/{year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByYear(Int16 year)
        {
            List<DVD> dvd = _dvdRepository.GetByYear(year);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/director/{director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string director)
        {
            List<DVD> dvd = _dvdRepository.GetByDirector(director);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvds/rating/{rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string rating)
        {
            List<DVD> dvd = _dvdRepository.GetByRating(rating);

            if (dvd == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(dvd);
            }
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Post([FromBody]DVD dvd)
        {
            if (dvd == null)
              return BadRequest("Bad data");

            int newId = _dvdRepository.AddDVD(dvd);
            if (newId > -1)
                return Ok(newId);
            else
                return BadRequest("Not Added");

        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Put(int id, [FromBody]DVD dvd)
        {
            if (dvd == null)
                return BadRequest("Bad data");

            _dvdRepository.UpdateDVD(id, dvd);
           
            return Ok();
        }
 
        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id)
        {
            _dvdRepository.DeleteDVD(id);
        }
    }
}