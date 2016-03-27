﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VotingAPI
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hometown { get; set; }
        public string District { get; set; }
        public string Party { get; set; }
        public virtual List<Race> Races { get; set; } 
    }
}