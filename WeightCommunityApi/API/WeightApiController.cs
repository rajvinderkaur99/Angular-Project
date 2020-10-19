using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeightCommunityApi.Models;

namespace WeightCommunityApi.API
{
    public class WeightApiController : ApiController
    {
        ApplicationDbContext _context;
        public WeightApiController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/WeightApi
        [HttpGet]
        public IHttpActionResult GetWeight()
        {
            var weights = _context.Weights.ToList();
            if (weights == null)
            {
                return NotFound();
            }
            return Ok(weights);
        }



        public IHttpActionResult GetWeight(int id)
        {
            if (id <= 0)
                return BadRequest("Not a Valid Product id");
            var product = _context.Weights.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        //POST /api/products
        [HttpPost]
        public IHttpActionResult AddWeight(Weight weight)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model data is invalid");
            _context.Weights.Add(weight);
            _context.SaveChanges();
            return Ok(weight);

        }



        //PUT /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateWeight(int id, Weight weight)
        {
            if (!ModelState.IsValid)

                return BadRequest("Invalid data");
            var productInDb = _context.Weights.SingleOrDefault(c => c.Id == id);
            if (productInDb == null)
                return NotFound();
            productInDb.weight = weight.weight;
            productInDb.bodyfat = weight.bodyfat;
            productInDb.date= weight.date;
            _context.SaveChanges();
            return Ok();


        }
        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteWeight(int id)
        {
            if (id <= 0)
                return BadRequest("Not a Valid Product id");
            var productInDb = _context.Weights.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();
            _context.Weights.Remove(productInDb);
            _context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
