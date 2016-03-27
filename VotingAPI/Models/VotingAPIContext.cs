using System.Data.Entity;

namespace VotingAPI.Models
{
    public class VotingAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public VotingAPIContext() : base("name=VotingAPIContext")
        {
        }

        public System.Data.Entity.DbSet<VotingAPI.Candidate> Candidates { get; set; }

        public System.Data.Entity.DbSet<VotingAPI.Voter> Voters { get; set; }

        public System.Data.Entity.DbSet<VotingAPI.Vote> Votes { get; set; }

        public System.Data.Entity.DbSet<VotingAPI.Race> Races { get; set; }
    }
}
