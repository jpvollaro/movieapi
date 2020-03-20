using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        public List<Movie> movieList = new List<Movie>()
        {
            new Movie("Rocky", "Its Rocky", 1979, "Drama", 4),
            new Movie("Test2", "Test Description", 1966, "Action", 1)
        };

        public MovieController()
        {
        }

        /// <summary>
        /// Get this instance.
        /// </summary>
        /// <returns>The get.</returns>
        [HttpGet]
        //[ProducesResponseType(typeof(Result), 200)]
        [Produces("application/json")]
        public async Task<Result> Get()
        {
            Result theResult = new Result()
            {
                status = "ok",
                totalResults = movieList.Count,
                movies = movieList
            };
            return await Task.FromResult(theResult);
        }
    }

    public class Result
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Movie> movies { get; set; }
    }

    public class Movie
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public uint year { get; set; }
        public string genre { get; set; }
        public int rating { get; set; }

        public Movie(string theName, string theDescription, uint theYear, string theGenre, int theRating)
        {
            id = Guid.NewGuid();
            name = theName;
            description = theDescription;
            year = theYear;
            genre = theGenre;
            rating = theRating;
        }
    }
}