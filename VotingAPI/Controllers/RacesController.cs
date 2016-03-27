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
using VotingAPI;
using VotingAPI.Models;

namespace VotingAPI.Controllers
{
    public class RacesController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        // GET: api/Races
        public IQueryable<Race> GetRaces()
        {
            return db.Races;
        }

        // GET: api/Races/5
        [ResponseType(typeof(Race))]
        public IHttpActionResult GetRace(int id)
        {
            Race race = db.Races.Find(id);
            if (race == null)
            {
                return NotFound();
            }

            return Ok(race);
        }

        // PUT: api/Races/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRace(int id, Race race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != race.Id)
            {
                return BadRequest();
            }

            db.Entry(race).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
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

        // POST: api/Races
        [ResponseType(typeof(Race))]
        public IHttpActionResult PostRace(Race race)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Races.Add(race);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = race.Id }, race);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RaceExists(int id)
        {
            return db.Races.Count(e => e.Id == id) > 0;
        }
    }
}