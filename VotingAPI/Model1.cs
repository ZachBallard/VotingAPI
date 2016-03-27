using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VotingAPI
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Model1 : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'VotingAPI.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public Model1()
            : base("name=Model1")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Voter> Voters { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Candidate> Candidates { get; set; }  
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Vote
    {
        public int Id { get; set; }
        public virtual List<Voter> Voters { get; set; } = new List<Voter>();
        public virtual Race Race { get; set; }
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
        public virtual List<Race> Races { get; set; } = new List<Race>();
    }
}