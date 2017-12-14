/*
 * ITSE 1430
 * Sample implementation
 */
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MovieLib.Web.Models
{
    /// <summary>Provides a view model for movies.</summary>
    public class MovieViewModel : IValidatableObject
    {
        public int Id { get; set; }

        /// <update>
        /// Validated the title length
        /// Stephen Aranda
        /// </update>
        [StringLength(100,MinimumLength,2, ErrorMessage="Title must be between 2 and 100 characters.")]
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string Description { get; set; }
        
        [Display(Name = "Is Owned")]
        public bool IsOwned { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Length { get; set; }

        public Rating Rating { get; set; }

        /// <update>
        /// Validated the release year to be between 1900 and 2100
        /// Stephen Aranda
        /// </update>
        [Range(1900,2100, ErrorMessage = "Year must be between 1900 and 2100")]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext ) => Enumerable.Empty<ValidationResult>();        
    }
}