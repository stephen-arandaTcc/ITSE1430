﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile
{
    /// <summary>Represents a product.</summary>
    /// <remarks>
    /// This will represent a product with other stuff.
    /// </remarks>
    public class Product : IValidatableObject
    {
       
       

        /// <summary>Gets or sets the unique identifier.</summary>
        public int Id { get; set; }

       

        /// <summary>Gets or sets the name.</summary>
        /// <value>Never returns null.</value>
        public string Name
        {
            // string get_Name ()
            get{return _name ?? ""; }

            // void set_Name ( string value )
            set{_name = value?.Trim();
            }
        }
        
        /// <summary>Gets or sets the description.</summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value?.Trim(); }
        }

        /// <summary>Gets or sets the price.</summary>
        public decimal Price { get; set; } = 0;      

        /// <summary>Determines if discontinued.</summary>
        public bool IsDiscontinued { get; set; }

        public const decimal DiscontinuedDiscountRate = 0.10M;

        /// <summary>Gets the discounted price, if applicable.</summary>
     

        public override string ToString()
        {
            return Name;
        }

        //Size of the product
        public int[] Sizes
        {
            get 
            {
                var copySizes = new int[_sizes.Length];
                Array.Copy(_sizes, copySizes, _sizes.Length);

                return copySizes;
            }
        }

        private int[] _sizes = new int[4];

        //public abstract string Validate2();

        //IEnumerable<ValidationResult> IValidatableObject.Validate( ValidationContext validationContext )
        //{

        //}
        /// <summary>Validates the object.</summary>
        /// <returns>The error message or null.</returns>      
        public IEnumerable<ValidationResult> Validate( ValidationContext validationContext )
        {
            //var errors = new List<ValidationResult>();

            //Name cannot be empty
            if (String.IsNullOrEmpty(Name))
                yield return new ValidationResult("Name cannot be empty.", new[] { nameof(Name) });
            //errors.Add(new ValidationResult("Name cannot be empty.", new[] { nameof(Name) }));

            //Price >= 0
            if (Price < 0)
                yield return new ValidationResult("Price must be >= 0.", new[] { nameof(Price) });
            //errors.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(Price) }));

            //return errors;
        }

        

        private string _name;
        private string _description;

      
    }
}
