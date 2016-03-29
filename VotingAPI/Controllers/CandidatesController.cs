using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using VotingAPI.Models;

namespace VotingAPI.Controllers
{
    public class CandidatesController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();
        
        // GET: api/Candidates
        public IQueryable<Candidate> GetCandidates()
        {
            return db.Candidates;
        }

        // GET: api/Candidates/5
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult GetCandidate(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        // POST: api/Candidates
        [ResponseType(typeof(Candidate))]
        public IHttpActionResult PostCandidate(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Candidates.Add(candidate);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = candidate.Id }, candidate);
        }
    }
}