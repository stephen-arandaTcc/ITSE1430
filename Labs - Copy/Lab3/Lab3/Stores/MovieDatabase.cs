//Stephen Aranda
// 11/1/2017
//ITSE 1430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLib;

namespace Stores
{
    /// <summary>Provides the base implementation of IMovieDatabase.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {

        /// <summary>Adds a movie </summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie.</returns>
        public Movie Add( Movie movie )
        {
            //Validate
            if (movie == null)
                return null;

            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            return AddCore(movie);
        }

        /// <summary>Gets a specific movie</summary>        
        /// <returns>The movie, if it exists.</returns>
        public Movie Get( int id )
        {
            //Validate
            if (id <= 0)
                return null;
            return GetCore(id);
        }

        /// <summary>Get all of the movies. </summary>
        /// <returns>The movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        /// <summary>Remove the movie.</summary>
        /// <param name="id">The movie to remove</param>
        public void Remove( int id )
        {
            if (id <= 0)
                return;
            RemoveCore(id);
        }


        /// <summary>Updates a movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        public Movie Update( Movie movie )
        {
            // Validate
            if (movie == null)
                return null;

            if (!ObjectValidator.TryValidate(movie, out var errors))
                return null;

            // Get the existing movie
            var existing = GetCore(movie.Id);
            if (existing == null)
                return null;

            // Return updated movie
            return UpdateCore(existing, movie);
        }

        /// <summary>Adds a movie </summary>
        /// <param name="movie">The movie to be added.</param>
        /// <returns>The added movie</returns>
        protected abstract Movie AddCore( Movie movie );

        /// <summary>Get a movie given the movie id </summary>
        /// <param name="id">The id for movie</param>
        /// <returns>The movie if it exists.</returns>
        protected abstract Movie GetCore(int id);

       protected abstract IEnumerable<Movie> GetAllCore();

        /// <summary>Removes a movie given its id. </summary>
        /// <param name="id">The id for movie.</param>
        protected abstract void RemoveCore( int id );


        /// <summary>Updates a movie. </summary>
        /// <param name="existing">The existing movie.</param>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        protected abstract Movie UpdateCore( Movie existing, Movie movie );
    }
}
