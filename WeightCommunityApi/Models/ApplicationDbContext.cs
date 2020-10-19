using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WeightCommunityApi.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Weight> Weights { get; set; }
        public DbSet<Community> Communities{ get; set; }
    }
}