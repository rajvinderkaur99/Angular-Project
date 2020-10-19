using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeightCommunityApi.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public string date { get; set; }
        public int weight { get; set; }
        public float bodyfat { get; set; }

    }
}