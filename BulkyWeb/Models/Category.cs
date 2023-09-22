using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    /// <summary>
    /// Information of category
    /// CreatedBy: ThiepTT(22/09/2023) 
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id of category
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// Name of category
        /// </summary>
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Display order
        /// </summary>
        [DisplayName("Display Order")]
        [Range(0, 100)]
        public int DisplayOrder  { get; set; }
    }
}
