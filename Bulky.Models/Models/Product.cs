using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bulky.Model.Models
{
    /// <summary>
    /// Information of product
    /// CreatedBy: ThiepTT(28/09/2023)
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Id of product
        /// </summary>
        [Key]
        public int ProductId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [Required]
        public string Title { get; set; } = string.Empty;


        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// ISBN
        /// </summary>
        [Required]
        public string ISBN { get; set; } = string.Empty;

        /// <summary>
        /// Author
        /// </summary>
        [Required]
        public string Author { get; set; } = string.Empty;

        /// <summary>
        /// List price
        /// </summary>
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [Required]
        [Display(Name = "Price for 1-50+")]
        [Range(1, 1000)]
        public double Price { get; set; }

        /// <summary>
        /// Price 50
        /// </summary>
        [Required]
        [Display(Name = "Price for 50+")]
        [Range(1, 1000)]
        public double Price50 { get; set; }

        /// <summary>
        /// Price 100
        /// </summary>
        [Required]
        [Display(Name = "Price for 100+")]
        [Range(1, 1000)]
        public double Price100 { get; set; }

        /// <summary>
        /// Id of category
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = default!;

        /// <summary>
        /// Image url
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;
    }
}