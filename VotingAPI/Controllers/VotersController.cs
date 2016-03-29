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
    public class VotersController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        [Route("api/Voters/{token}")]
        [ResponseType(typeof(Voter))]
        public IHttpActionResult GetVoter(string token)
        {
            Voter voter = db.Voters.Find(token);
            if (voter == null)
            {
                return NotFound();
            }

            return Ok(voter);
        }
        [Route("api/Voters/{token}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVoter(string token, Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (token != voter.Token)
            {
                return BadRequest();
            }

            db.Entry(voter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoterExists(token))
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

        // POST: api/Voters
        [ResponseType(typeof(Voter))]
        public IHttpActionResult PostVoter(Voter voter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Voters.Add(voter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = voter.Id }, voter);
        }

        private bool VoterExists(string token)
        {
            return db.Voters.Count(e => e.Token == token) > 0;
        }
    }
}