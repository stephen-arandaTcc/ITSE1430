// Stephen Aranda
// 11/1/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLib;

namespace Stores
{
    /// <summary>Provides an implementation of <see cref="IMovieDatabase> using a memory collection.</summary>
    public class MemoryMovieDatabase : MovieDatabase
    {
        /// <summary>Adds a movie. </summary>
        /// <param name="movie">The movie to be added.</param>
        /// <returns>The added movie.</returns>
        protected override Movie AddCore( Movie movie )
        {
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            if (newMovie.Id <= 0)
                newMovie.Id = _nextId++;
            else if (newMovie.Id >= _nextId)
                _nextId = newMovie.Id + 1;

            return CopyMovie(newMovie);
        }

        /// <summary>Gets all the movies. </summary>
        /// <returns>All the movies.</returns>
        protected override IEnumerable<Movie> GetAllCore()
        {
            foreach(var movie in _movies)
                yield return CopyMovie(movie);
        }

        /// <summary>Gets a specific movie. </summary>
        /// <param name="id">The id of the movie.</param>
        /// <returns>The movie, if it exists.</returns>
        protected override Movie GetCore( int id )
        {
            var movie = FindMovie(id);

            return (movie != null) ? CopyMovie(movie) : null;            
        }

        /// <summary>Removes the movie. </summary>
        /// <param name="id">The movie to be removed.</param>
        protected override void RemoveCore( int id )
        {
            var movie = FindMovie(id);

            if (movie != null)
                _movies.Remove(movie);
        }

        /// <summary>Updates a movie. </summary>        
        /// <param name="movie">The movie to update</param>
        /// <returns>The updated movie.</returns>
       protected override Movie UpdateCore( Movie existing, Movie movie )
        {
            //Find and remove the existing movie
            existing = FindMovie(movie.Id);
            _movies.Remove(existing);

            //Add copy of new movie.
            var newMovie = CopyMovie(movie);
            _movies.Add(newMovie);

            return CopyMovie(newMovie);

        }

        // Copies one movie to another.
        private Movie CopyMovie( Movie movie )
        {
            if (movie == null)
                return null;

            // Movie movie is copied to newMovie
            var newMovie = new Movie();
            newMovie.Id = movie.Id;
            newMovie.Title = movie.Title;
            newMovie.Description = movie.Description;
            newMovie.Length = movie.Length;
            newMovie.IsOwned = movie.IsOwned;

            return newMovie;
        }

        //Finds the movie using an id
        private Movie FindMovie(int id)
        {
            foreach(var movie in _movies)
            {
                if (movie.Id == id)
                    return movie;
            };

            return null;
        }

        private List<Movie> _movies = new List<Movie>();
        private int _nextId = 1;
    }
}
