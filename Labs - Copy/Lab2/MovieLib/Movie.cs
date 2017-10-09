// Stephen Aranda
// 10/9/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>Represents a movie.</summary>
/// <remarks>
/// This will represent the information of the movie.
/// </remarks>
namespace MovieLib
{
    public class Movie
    {
        public Movie()
        {

        }


        /// <value>Never returns a null</value>
        public string Title
        {
            
            get {
                return _title ?? "";
            }

            
            set {
                _title = value?.Trim();
            }
        }

        public string Description
        {
            get
            {
                return _description ?? "";
            }

            set
            {
                _description = value?.Trim();
            }
        }

        public int Length { get; set; } = 0;

        public bool IsOwned { get; set; }

        public override string ToString()
        {
            return Title;
        }

        public virtual string Validate()
        {
            if (String.IsNullOrEmpty(Title))
                return "Name cannot be empty.";

            if (Length < 0)
                return "Length must be >= 0.";

            return null;
        }

        private string _title;
        private string _description;
    }
}
