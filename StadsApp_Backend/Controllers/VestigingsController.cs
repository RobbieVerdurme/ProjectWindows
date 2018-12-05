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
    public class VestigingsController : ApiController
    {
        private StadsApp_BackendContext db = new StadsApp_BackendContext();

        // GET: api/Vestigings
        public IQueryable<Vestiging> GetVestigings()
        {
            return db.Vestigings;
        }

        // GET: api/Vestigings/5
        [ResponseType(typeof(Vestiging))]
        public IHttpActionResult GetVestiging(int id)
        {
            Vestiging vestiging = db.Vestigings.Find(id);
            if (vestiging == null)
            {
                return NotFound();
            }

            return Ok(vestiging);
        }

        // PUT: api/Vestigings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVestiging(int id, Vestiging vestiging)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vestiging.VestigingId)
            {
                return BadRequest();
            }

            db.Entry(vestiging).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VestigingExists(id))
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

        // POST: api/Vestigings
        [ResponseType(typeof(Vestiging))]
        public IHttpActionResult PostVestiging(Vestiging vestiging)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Vestigings.Add(vestiging);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vestiging.VestigingId }, vestiging);
        }

        // DELETE: api/Vestigings/5
        [ResponseType(typeof(Vestiging))]
        public IHttpActionResult DeleteVestiging(int id)
        {
            Vestiging vestiging = db.Vestigings.Find(id);
            if (vestiging == null)
            {
                return NotFound();
            }

            db.Vestigings.Remove(vestiging);
            db.SaveChanges();

            return Ok(vestiging);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VestigingExists(int id)
        {
            return db.Vestigings.Count(e => e.VestigingId == id) > 0;
        }
    }
}