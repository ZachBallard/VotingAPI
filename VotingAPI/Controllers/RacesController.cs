﻿using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
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
    }
}