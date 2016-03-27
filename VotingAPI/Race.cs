using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Candidate> Candidates { get; set; } 
        public virtual List<Vote> Votes { get; set; }
    }
}