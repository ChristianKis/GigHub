using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers
{
    public class FollowController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FollowController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowDto followDto)
        {
            var userId = User.Identity.GetUserId();

            if (_context.Follows.Any(f => f.UserId == userId && f.ArtistId == followDto.ArtistId))
                return BadRequest("User already follows follow.");

            var follow = new Follow
            {
                UserId = userId,
                ArtistId = followDto.ArtistId
            };

            _context.Follows.Add(follow);
            _context.SaveChanges();

            return Ok();
        }
    }
}