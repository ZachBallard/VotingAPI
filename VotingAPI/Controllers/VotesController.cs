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
    public class VotesController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        // GET: api/Votes
        public List<Candidate> GetVotes()
        {
            return db.Candidates.ToList();
        }

        [Route("api/Votes/{token}/{id}")]
        // POST: api/Votes
        [ResponseType(typeof(Vote))]
        public string PostVote(string token, int id, Vote vote)
        {
            bool isValidToken = false;
            if (id <= db.Candidates.Local.Count)
            {
                foreach (var v in db.Voters)
                {
                    if (v.Token == token)
                    {
                        isValidToken = true;
                        break;
                    }
                }

                if (isValidToken)
                {
                    db.Votes.Add(vote);
                    db.SaveChanges();
                    return "Vote has been cast";
                }
            }

            return "Invalid token, candidate id, or vote";
        }

        [Route("api/Votes/{token}")]
        // DELETE: api/Votes/5
        [ResponseType(typeof(Vote))]
        public IHttpActionResult DeleteVote(string token)
        {
            Voter voter = db.Voters.Find(token);
            
            if (voter.Vote == null)
            {
                return NotFound();
            }

            db.Votes.Remove(voter.Vote);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoteExists(int id)
        {
            return db.Votes.Count(e => e.Id == id) > 0;
        }
    }
}