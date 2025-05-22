using MarcAiAPI.Domain.Entities.Review;
using MarcAiAPI.Domain.Interfaces.Store;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.Store
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }

        [HttpGet("GetAllReviews")]
        public IActionResult GetAllReviews()
        {
            var result = _service.GetAllReviewsAsync();
            return Ok(result);
        }

        [HttpGet("GetReviewById/{id}")]
        public IActionResult GetReviewById([FromQuery]long id)
        {
            var result = _service.GetReviewAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateReview")]
        public IActionResult CreateReview([FromBody] ReviewEntity review)
        {
            var result = _service.InsertReviewAsync(review);
            return Ok(result);
        }

        [HttpPut("UpdateReview")]
        public IActionResult UpdateReview([FromBody] ReviewEntity review)
        {
            var result = _service.UpdateReviewAsync(review);
            return Ok(result);
        }

        [HttpDelete("DeleteReview/{id}")]
        public IActionResult DeleteReview([FromQuery]long id)
        {
            var result = _service.DeleteReviewAsync(id);
            return Ok(result);
        }
    }
}