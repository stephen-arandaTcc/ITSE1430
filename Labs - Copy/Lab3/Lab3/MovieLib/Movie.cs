// Stephen Aranda
// 11/1/2017
// ITSE 1430
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>Represents a movie.</summary>
/// <remarks>This will represent the information of the movie.</remarks>
namespace MovieLib
{
    public class Movie : IValidatableObject
    {
        /// <summary>Gets or sets the unique identifier for movie.</summary>
        public int Id { get; set; }


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

        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //Title cannot be empty
            if (String.IsNullOrEmpty(Title))
                yield return new ValidationResult("Title cannot be empty.", new[] { nameof(Title) });

            //Length >= 0
            if (Length < 0)
                yield return new ValidationResult("Length must be >= 0.", new[] { nameof(Length) });
        }

        private string _title;
        private string _description;
    }
}
