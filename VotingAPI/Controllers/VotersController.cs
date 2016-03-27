using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using VotingAPI.Models;

namespace VotingAPI.Controllers
{
    public class VotersController : ApiController
    {
        private VotingAPIContext db = new VotingAPIContext();

        // GET: api/Voters
        public IQueryable<Voter> GetVoters()
        {
            return db.Voters;
        }

        // GET: api/Voters/5
        [ResponseType(typeof(Voter))]
        public IHttpActionResult GetVoter(int id)
        {
            Voter voter = db.Voters.Find(id);
            if (voter == null)
            {
                return NotFound();
            }

            return Ok(voter);
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VoterExists(int id)
        {
            return db.Voters.Count(e => e.Id == id) > 0;
        }
    }
}