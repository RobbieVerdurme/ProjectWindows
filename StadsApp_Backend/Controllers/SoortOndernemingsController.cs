using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using StadsApp_Backend.Models;

namespace StadsApp_Backend.Controllers
{
    public class SoortOndernemingsController : ApiController
    {
        private StadsApp_BackendContext db = new StadsApp_BackendContext();

        // GET: api/SoortOndernemings
        public IQueryable<SoortOnderneming> GetSoortOndernemings()
        {
            return db.SoortOndernemings;
        }

        // GET: api/SoortOndernemings/5
        [ResponseType(typeof(SoortOnderneming))]
        public IHttpActionResult GetSoortOnderneming(int id)
        {
            SoortOnderneming soortOnderneming = db.SoortOndernemings.Find(id);
            if (soortOnderneming == null)
            {
                return NotFound();
            }

            return Ok(soortOnderneming);
        }

        // PUT: api/SoortOndernemings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSoortOnderneming(int id, SoortOnderneming soortOnderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != soortOnderneming.SoortID)
            {
                return BadRequest();
            }

            db.Entry(soortOnderneming).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoortOndernemingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SoortOndernemings
        [ResponseType(typeof(SoortOnderneming))]
        public IHttpActionResult PostSoortOnderneming(SoortOnderneming soortOnderneming)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SoortOndernemings.Add(soortOnderneming);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = soortOnderneming.SoortID }, soortOnderneming);
        }

        // DELETE: api/SoortOndernemings/5
        [ResponseType(typeof(SoortOnderneming))]
        public IHttpActionResult DeleteSoortOnderneming(int id)
        {
            SoortOnderneming soortOnderneming = db.SoortOndernemings.Find(id);
            if (soortOnderneming == null)
            {
                return NotFound();
            }

            db.SoortOndernemings.Remove(soortOnderneming);
            db.SaveChanges();

            return Ok(soortOnderneming);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoortOndernemingExists(int id)
        {
            return db.SoortOndernemings.Count(e => e.SoortID == id) > 0;
        }
    }
}