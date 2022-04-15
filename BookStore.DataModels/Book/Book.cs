using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.DataModels.Book
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Quantity { set; get; }
        [Required]
        public decimal Price { set; get; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Store.Store Store { get; set; }

        public int AuthorId { set; get; }
        [ForeignKey("AuthorId")]
        public virtual Author.Author Author { set; get; }
    }
}
