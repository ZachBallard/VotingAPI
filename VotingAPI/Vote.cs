using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Vote
    {
        public int Id { get; set; }
        public virtual Voter Voter { get; set; }
        public virtual Race Race { get; set; }
    }
}