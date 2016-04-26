using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public System.Data.Entity.DbSet<Candidate> Candidates { get; set; }

        public System.Data.Entity.DbSet<Voter> Voters { get; set; }

        public System.Data.Entity.DbSet<Vote> Votes { get; set; }

        public System.Data.Entity.DbSet<Race> Races { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Vote
    {
        public int Id { get; set; }
        public virtual Candidate Candidate { get; set; }
        public virtual Race Race { get; set; }
        public virtual Voter Voter { get; set; }
    }

    public class Voter
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; } //will be guid to string()
        public string Party { get; set; }
        public virtual Vote Vote { get; set; }
    }

    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Candidate> Candidates { get; set; } = new List<Candidate>();
        public virtual List<Vote> Votes { get; set; } = new List<Vote>();
    }

    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Hometown { get; set; }
        public string District { get; set; }
        public string Party { get; set; }
        public virtual List<Vote> Votes { get; set; } = new List<Vote>();
        public virtual List<Race> Races { get; set; } = new List<Race>();
    }
}
    }
}
