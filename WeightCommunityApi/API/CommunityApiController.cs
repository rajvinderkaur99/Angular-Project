using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeightCommunityApi.Models;

namespace WeightCommunityApi.API
{
    public class CommunityApiController : ApiController
    {
        ApplicationDbContext _context;
        public CommunityApiController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/CommuntyApi
        public IHttpActionResult GetCommunity()
        {
            var weights = _context.Communities.ToList();
            if (weights == null)
            {
                return NotFound();
            }
            return Ok(weights);
        }



        public IHttpActionResult GetCommunity(int id)
        {
            if (id <= 0)
                return BadRequest("Not a Valid Product id");
            var product = _context.Communities.SingleOrDefault(c => c.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        //POST /api/products
        [HttpPost]
        public IHttpActionResult AddComment(Community community)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model data is invalid");
            _context.Communities.Add(community);
            _context.SaveChanges();
            return Ok(community);

        }



        //PUT /api/products/1
        [HttpPut]
        public IHttpActionResult UpdateComment(int id, Community community)
        {
            if (!ModelState.IsValid)

                return BadRequest("Invalid data");
            var productInDb = _context.Communities.SingleOrDefault(c => c.Id == id);
            if (productInDb == null)
                return NotFound();
            productInDb.comment = community.comment;
            productInDb.Commenter = community.Commenter;
            _context.SaveChanges();
            return Ok();


        }
        //DELETE /api/customers/1
        public IHttpActionResult DeleteComment(int id)
        {
            if (id <= 0)
                return BadRequest("Not a Valid Product id");
            var productInDb = _context.Communities.SingleOrDefault(c => c.Id == id);

            if (productInDb == null)
                return NotFound();
            _context.Communities.Remove(productInDb);
            _context.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
