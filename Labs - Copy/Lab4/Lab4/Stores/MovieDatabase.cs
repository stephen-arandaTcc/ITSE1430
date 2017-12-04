// Stephen Aranda
// 12/4/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLib;
using System.ComponentModel.DataAnnotations;

namespace Stores
{
    /// <summary>Provides the base implementation of IMovieDatabase.</summary>
    /// <remarks>Updating class with exception handling.</remarks>
    public abstract class MovieDatabase : IMovieDatabase
    {

        /// <summary>Adds a movie </summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/>is null.</exception>
        /// <exception cref="ValidationException"><paramref name="movie"/> is invalid.</exception>
        /// <exception cref="ArgumentException"><paramref name="movie"/>Movie with the same title exists.</exception>
        public Movie Add( Movie movie )
        {
            //Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie),"Movie was null.");

            


            if (!ObjectValidator.TryValidate(movie, out var errors))
                throw new ValidationException("Movie was not valid");

            foreach( var existing in GetAll())
            {
                // Check to see if the movie being added has the same title as an existing movie.
                if (movie.Title == existing.Title)
                    throw new ArgumentException(movie.Title, "Movie with the same title already exists.");
            }

           

            try
            {
                return AddCore(movie);
            }
            catch (Exception e)
            {
                throw new Exception("Add failed.", e);
            };
        }

        /// <summary>Gets a specific movie</summary>        
        /// <returns>The movie, if it exists.</returns>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/>must be greater than or equal to 0.</exception>
        public Movie Get( int id )
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be => 0.");

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
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="id"/>must be greater than or equal to 0.</exception>
        public void Remove( int id )
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be => 0.");
            RemoveCore(id);
        }


        /// <summary>Updates a movie.</summary>
        /// <param name="movie">The movie to update.</param>
        /// <returns>The updated movie.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="movie"/>is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="movie"/>is invalid.</exception>
        /// <exception cref="Exception"><paramref name="movie"/>movie not found.</exception>
        /// <exception cref="ArgumentException"><paramref name="movie"/>Movie with the same title exists.</exception>
        public Movie Update( Movie movie )
        {
            // Validate
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            if (!ObjectValidator.TryValidate(movie, out var errors))
              throw new ArgumentException("Movie is invalid.", nameof(movie));
            
            // Get the existing movie. 
            var existing = GetCore(movie.Id) ?? throw new Exception("Movie was not found.");

            

            // Return updated movie
            return UpdateCore( existing,movie);
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
